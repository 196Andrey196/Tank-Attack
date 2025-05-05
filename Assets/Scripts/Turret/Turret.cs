using System;
using System.Collections;
using UnityEngine;


public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject[] _allTurretGuns;
    public int countPrepareGun;
    public bool isAnyWeaponReady;
    public Action<ShootGun> allReloadGun;
    void Start()
    {
        countPrepareGun = _allTurretGuns.Length;
        StartCoroutine(CheckWeaponsStatus());
    }
    public GameObject GetGun()
    {
        foreach (var gun in _allTurretGuns)
        {
            ShootGun gunParam = gun.GetComponent<ShootGun>();
            if (gunParam != null && gunParam.canShoot) return gun;
        }
        return null;
    }
    public IEnumerator CheckWeaponsStatus()
    {
        while (true)
        {
            int readyCount = 0;

            foreach (var gun in _allTurretGuns)
            {
                ShootGun gunParam = gun.GetComponent<ShootGun>();
                if (gunParam != null && gunParam.canShoot)
                {
                    readyCount++;
                }
            }

            countPrepareGun = readyCount;
            isAnyWeaponReady = readyCount > 0;
            ShootGun firstGun = _allTurretGuns[0].GetComponent<ShootGun>();
            if (!isAnyWeaponReady) allReloadGun?.Invoke(firstGun);


            yield return null;
        }
    }

}


