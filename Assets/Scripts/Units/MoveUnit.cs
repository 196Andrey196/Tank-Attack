using UnityEngine;
using DG.Tweening;
using System;

public class MoveUnit : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _rotationDuration = 1;
    private float _moveSpeed = 15f;
    private float _stopDistance = 18f;
    [SerializeField] private Tween _currentTween;

    public Action<GameObject> startMoveToTarget;

    void OnEnable()
    {
        startMoveToTarget += MoveToTarget;
        StartIdleMovement();

    }

    void OnDisable()
    {
        transform.localRotation = Quaternion.identity;
        startMoveToTarget -= MoveToTarget;
    }


    private void StartIdleMovement()
    {
        _currentTween?.Kill();
        Vector3 targetPosition = transform.position + (-transform.forward * 1000f);
        targetPosition.y = transform.position.y; 
        _currentTween = transform.DOMove(targetPosition, 1000f / _moveSpeed)
            .SetEase(Ease.Linear);
    }

    private void MoveToTarget(GameObject target)
    {
        _currentTween?.Kill();
        _target = target.transform;
        Vector3 direction = _target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.DORotateQuaternion(targetRotation, _rotationDuration);
        Vector3 stopPosition = _target.position - direction.normalized * _stopDistance;
        _currentTween = transform.DOMove(stopPosition, _moveSpeed / 10f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                    Attack attack = GetComponent<Attack>();
                    if (attack != null)
                    {
                        attack.OnTargetReached?.Invoke();
                    }
                
            });
    }

}


