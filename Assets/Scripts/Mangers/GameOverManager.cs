using System;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{
    public static Action onGameOver;

    [SerializeField] private RectTransform _gameOverMenu;

    private void OnEnable()
    {
        onGameOver += ShowGameOverMenu;
    }

    private void OnDisable()
    {
        onGameOver -= ShowGameOverMenu;
    }

    private void ShowGameOverMenu()
    {
        MenuAnimator.Instance.ShowMenu(_gameOverMenu);
    }
}

