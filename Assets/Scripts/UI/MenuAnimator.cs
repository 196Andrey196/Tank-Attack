using DG.Tweening;
using UnityEngine;


public class MenuAnimator : MonoBehaviour
{
    public static MenuAnimator Instance { get; private set; }

    [SerializeField] private float _duration = 0.3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void ShowMenu(RectTransform menuTransform)
    {
        menuTransform.gameObject.SetActive(true);
        menuTransform.DOScale(Vector3.one, _duration)
            .SetEase(Ease.OutBack)
            .SetUpdate(true);
        Time.timeScale = 0f;
    }

    public void HideMenu(RectTransform menuTransform)
    {
        menuTransform.DOScale(Vector3.zero, _duration)
            .SetEase(Ease.InBack)
            .SetUpdate(true)
            .OnComplete(() => menuTransform.gameObject.SetActive(false));
        Time.timeScale = 1f;
    }
}

