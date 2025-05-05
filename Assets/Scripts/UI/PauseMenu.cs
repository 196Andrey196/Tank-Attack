using System;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
[SerializeField] private Button _exitBTN;
 [SerializeField] private Button _continiueBTN;
    void Start()
    {
        _exitBTN.onClick.AddListener(Exit);
        _continiueBTN.onClick.AddListener(Continiue);
        transform.localScale = Vector3.zero;
    }

    private void Continiue()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        MenuAnimator.Instance.HideMenu(rectTransform);
    }

    private void Exit()
    {
         Application.Quit();
    }
}

