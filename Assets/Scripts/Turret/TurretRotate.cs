using UnityEngine;


public class TurretRotate : MonoBehaviour
{
    [SerializeField] private Transform _turretHead;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _rotateSpeed;


    void Update()
    {
        Vector2 input = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        if (input.sqrMagnitude > 0.1f)
        {
            float angle = Mathf.Atan2(input.x, -input.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            _turretHead.rotation = Quaternion.Lerp(_turretHead.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
        }
    }
}

