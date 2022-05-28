using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;

    private Story _currentStory;

    public bool DialogueIsPlaying { get; private set; }

    private static DialogueManager _instance;

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
    }

    private void Update()
    {
        if(DialogueIsPlaying == false)
        {
            return;
        }


    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        _currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;
        _dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    private void ExitDialogueMode()
    {
        DialogueIsPlaying = false;
        _dialoguePanel.SetActive(false);
        _dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
