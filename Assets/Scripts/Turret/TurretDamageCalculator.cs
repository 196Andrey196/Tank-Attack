using System;

using DG.Tweening;
using UnityEngine;


public class TurretDamageCalculator : MonoBehaviour,ITakeDamage
{

    public void TakeDamage()
    {
        GameOverManager.onGameOver?.Invoke();
    }


}

