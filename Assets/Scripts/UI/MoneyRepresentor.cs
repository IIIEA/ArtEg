using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class MoneyRepresentor : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _countText;

    private void Awake()
    {
        _countText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.AmountChanged += OnAmountChanged;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= OnAmountChanged;
    }

    private void OnAmountChanged(int count)
    {
        _countText.text = count + "$";
    }
}
