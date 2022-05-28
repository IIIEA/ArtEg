using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour, IInteraction
{
    [SerializeField] private Button _dialugueButton;

    private void Start()
    {
        _dialugueButton.gameObject.SetActive(false);
    }

    public void EndInteract()
    {
        _dialugueButton.gameObject.SetActive(false);
    }

    public void StartInteract()
    {
        _dialugueButton.gameObject.SetActive(true);
    }
}
