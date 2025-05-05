using System;
using DG.Tweening;
using UnityEngine;


public class Attack : MonoBehaviour
{
    [SerializeField] private float _rotationDuration = 0.5f;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private AudioClip _fireSound;

    public Action OnTargetReached;

    void OnEnable()
    {
        OnTargetReached += OnAttack;
    }
    void OnDisable()
    {
        OnTargetReached += OnAttack;
    }

    private void OnAttack()
    {
        SoundManager.playEffect?.Invoke(_fireSound, 0.1f);
        _projectile.SetActive(true);
    }
}

