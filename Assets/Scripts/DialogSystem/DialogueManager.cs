using TMPro;
using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private GameObject _joystick;
    [SerializeField] private Wallet _wallet;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] _choices;

    private static DialogueManager _instance;

    private TMP_Text[] _choicesText;
    private Story _currentStory;

    private const string RightAnswerTag = "true";

    public bool DialogueIsPlaying { get; private set; }

    public UnityAction RightAnswerReached;

    private void Awake()
    {
        if(_instance != null)
        {
            Debug.LogWarning("More then 1");
        }

        _instance = this;
    }

    private void Start()
    {
        DialogueIsPlaying = false;
        _dialoguePanel.SetActive(false);

        _choicesText = new TextMeshProUGUI[_choices.Length];
        int index = 0;

        foreach(GameObject choice in _choices)
        {
            _choicesText[index] = choice.GetComponentInChildren<TMP_Text>();
            index++;
        }
    }

    private void Update()
    {
        if (DialogueIsPlaying == false)
        {
            return;
        }

        if (DialogueButton.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        _joystick.SetActive(false);
        _currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;
        _dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public void MakeChoice(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        _joystick.SetActive(true);
        DialogueIsPlaying = false;
        _dialoguePanel.SetActive(false);
        _dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue(); 
            DisplayChoices();

            HandleTags(_currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');

            if(splitTag.Length != 2)
            {
                Debug.Log("Error");
            }

            string tagValue = splitTag[1].Trim();

            if(tagValue == RightAnswerTag)
            {
                _wallet.AddMoney(50);
                RightAnswerReached?.Invoke();
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;

        if(currentChoices.Count > _choices.Length)
        {
            Debug.LogError("Can not support more choices");
        }

        int index = 0;

        foreach(Choice choice in currentChoices)
        {
            _choices[index].gameObject.SetActive(true);
            _choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < _choices.Length; i++)
        {
            _choices[i].gameObject.SetActive(false);
        }
    }
}
