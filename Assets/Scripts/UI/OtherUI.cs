using System;
using UnityEngine;
using UnityEngine.UI;


public class OtherUI : MonoBehaviour
{
    [SerializeField] private Button _upgradeBTN;
    [SerializeField] private Button _pauseBTN;
    [SerializeField] private UpgradeMannager _upgradeMannager;
    [SerializeField] private RectTransform _pauseMenu;
    void Start()
    {
        _upgradeBTN.onClick.AddListener(OnUpgrade);
        _pauseBTN.onClick.AddListener(SetPause);
    }

    private void SetPause()
    {
        MenuAnimator.Instance.ShowMenu(_pauseMenu);
    }

    private void OnUpgrade()
    {
        _upgradeMannager.upgradeTurret?.Invoke();
    }
}

