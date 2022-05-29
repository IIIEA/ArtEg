using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    private bool _interactPressed;
    private bool _submitPressed;

    private static DialogueButton _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }

        _instance = this;
    }

    public static DialogueButton GetInstance()
    {
        return _instance;
    }

    public void InteractPressed()
    {
        _interactPressed = true;
    }

    public bool GetInteractPressed()
    {
        bool result = _interactPressed;
        _interactPressed = false;
        return result;
    }

    public void SubmitPressed()
    {
        _submitPressed = true;
    }

    public bool GetSubmitPressed()
    {
        bool result = _submitPressed;
        _submitPressed = false;
        return result;
    }
}
