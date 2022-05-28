using UnityEngine;

public class EnterDialogueButton : MonoBehaviour
{
    private bool _interactPressed;

    private static EnterDialogueButton _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }

        _instance = this;
    }

    public static EnterDialogueButton GetInstance()
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
}
