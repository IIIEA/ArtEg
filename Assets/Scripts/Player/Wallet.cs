using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _amount = 0;

    public int Amount => _amount;

    public UnityAction<int> AmountChanged;

    private void Start()
    {
        AmountChanged?.Invoke(_amount);
    }

    public void AddMoney(int count)
    {
        _amount += count;
        AmountChanged?.Invoke(_amount);
    }
}
