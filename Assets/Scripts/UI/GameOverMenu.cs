using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _exitBTN;
    [SerializeField] private Button _restartBTN;
    void Start()
    {
        _exitBTN.onClick.AddListener(Exit);
        _restartBTN.onClick.AddListener(Restart);
        transform.localScale = Vector3.zero;
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Exit()
    {
        Application.Quit();
    }
}

