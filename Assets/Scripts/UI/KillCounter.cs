using System;
using TMPro;
using UnityEngine;


public class KillCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killText; 
    private int _killCount;

    public static Action onEnemyKilled;

    void Start()
    {
        _killText.text = 0.ToString();
    }
    void OnEnable()
    {
        onEnemyKilled += IncreaseKillCount;
    }

    void OnDisable()
    {
        onEnemyKilled -= IncreaseKillCount;
    }

    private void IncreaseKillCount()
    {
        _killCount++;
        _killText.text = _killCount.ToString();
    }
}

