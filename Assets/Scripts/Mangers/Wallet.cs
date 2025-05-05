using System;
using UnityEngine;


public class Wallet : MonoBehaviour
{
    [SerializeField] private int _currentMoneyInWallet;
    public int currentMoneyInWallet { get { return _currentMoneyInWallet; } }

    public static Action<int> OnCoinAdded;
    public static Action<int> OnCoinRemoved;
    public int CurrentMoney => _currentMoneyInWallet;

    void OnEnable()
    {
        OnCoinAdded += AddCoins;
        OnCoinRemoved += RemoveCoins;
    }
    void OnDisable()
    {
        OnCoinAdded -= AddCoins;
        OnCoinRemoved -= RemoveCoins;
    }

    public void AddCoins(int amount)
    {
        if (amount <= 0) return;
        _currentMoneyInWallet += amount;
        WalletUI.updateUI?.Invoke(_currentMoneyInWallet);
    }

    public void RemoveCoins(int amount)
    {
        if (amount <= 0 || amount > _currentMoneyInWallet) return;

        _currentMoneyInWallet -= amount;
        WalletUI.updateUI?.Invoke(_currentMoneyInWallet);
    }
}

