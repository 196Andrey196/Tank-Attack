using System;
using UnityEngine;


public class TurretStatus : MonoBehaviour
{
    [SerializeField] private Turret _currentTurret;
    public Turret currentTurret { get { return _currentTurret; } }
    public Action<GameObject> changeTurret;
    void OnEnable()
    {
        changeTurret += ChangeTurret;
    }
    void OnDisable()
    {
        changeTurret -= ChangeTurret;
    }

    private void ChangeTurret(GameObject newTurret)
    {
        if (newTurret != null)
        {
            Turret turret = newTurret.GetComponent<Turret>();
            if (turret != null) _currentTurret = turret;
        }
    }
}

