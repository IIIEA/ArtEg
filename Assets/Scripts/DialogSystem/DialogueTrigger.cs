using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _visualCue;
    [SerializeField] private TextAsset _inkJSON;

    private bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        _visualCue.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_playerInRange && DialogueManager.GetInstance().DialogueIsPlaying == false)
        {
            _visualCue.gameObject.SetActive(true);

            if (EnterDialogueButton.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(_inkJSON);
            }
        }
        else
        {
            _visualCue.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IInteraction>(out IInteraction interaction))
        {
            interaction.StartInteract();
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteraction>(out IInteraction interaction))
        {
            interaction.EndInteract();
            _playerInRange = false;
        }
    }
}
