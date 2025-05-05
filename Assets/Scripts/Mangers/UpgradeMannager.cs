
using System;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeMannager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _turretsLevelPrefabs;
    private int _upgradeCost = 100;
    private Wallet _wallet;
    private TurretStatus _turretStatus;
    public Action upgradeTurret;
    void Start()
    {
        _wallet = GetComponent<Wallet>();
        _turretStatus = GetComponent<TurretStatus>();
    }
    void OnEnable()
    {
        upgradeTurret += TryUpgradeTurret;
    }

    void OnDisable()
    {
        upgradeTurret -= TryUpgradeTurret;
    }

    private void TryUpgradeTurret()
    {
        if (_wallet.CurrentMoney >= _upgradeCost)
        {
            _wallet.RemoveCoins(_upgradeCost);
            UpgradeTurret();
        }
        else
        {
            Debug.Log("Не хватает монет для улучшения!");
        }
    }

    private void UpgradeTurret()
    {
        _turretsLevelPrefabs[0].SetActive(false);
        _turretsLevelPrefabs[1].SetActive(true);
        _turretStatus.changeTurret?.Invoke(_turretsLevelPrefabs[1]);
    }
}

