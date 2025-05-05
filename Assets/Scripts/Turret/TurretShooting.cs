using System;
using UnityEngine;


public class TurretShooting : MonoBehaviour
{
    [SerializeField] private GameObject _currentGun;
    private Turret _turret;
    public Action shoot;


    void OnEnable()
    {
        shoot += Shoot;
    }
    void OnDisable()
    {
        shoot -= Shoot;
    }
    void Start()
    {
        _turret = GetComponent<Turret>();
    }

    private void Shoot()
    {
        _currentGun = _turret.GetGun();
        if (_currentGun != null)
        {
            ShootGun shootGun = _currentGun.GetComponent<ShootGun>();
            shootGun.OnShoot();
        }
    }





}

