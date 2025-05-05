using System;
using TMPro;
using UnityEngine;


public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Wallet _wallet;
    public static Action<int> updateUI;

    private void Start()
    {
        UpdateUI(_wallet.CurrentMoney);
        _coinText.text = 0.ToString();
    }

    private void OnEnable()
    {
      updateUI += UpdateUI;
    }

    private void OnDisable()
    {
        updateUI -= UpdateUI;
    }

    private void UpdateUI(int newAmount)
    {
        _coinText.text = newAmount.ToString();
    }
}

