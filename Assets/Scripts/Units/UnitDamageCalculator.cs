using DG.Tweening;
using UnityEngine;


public class UnitDamageCalculator : MonoBehaviour, ITakeDamage
{
    public void TakeDamage()
    {
        Wallet.OnCoinAdded(10);
        KillCounter.onEnemyKilled?.Invoke();
        DOTween.Kill(transform);
        gameObject.SetActive(false);

    }


}

