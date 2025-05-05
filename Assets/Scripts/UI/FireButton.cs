using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FireButton : MonoBehaviour
{
    [SerializeField] private Button _fireBTN;
    [SerializeField] private Image _reloadBG;
    [SerializeField] private TextMeshProUGUI _reloadText;
    [SerializeField] private TurretStatus _turretStatus;
    [SerializeField] private Turret _turret;
    private TurretShooting _turretShooting;
    private ShootGun _currentGun;
    void Start()
    {
        _fireBTN.onClick.AddListener(OnFire);
        SetTurret();
    }
    private void OnDisable()
    {
        _turret.allReloadGun -= StartShowingReload;
    }
    private void SetTurret()
    {
        _turret = _turretStatus.currentTurret.GetComponent<Turret>();
        _turretShooting = _turret.gameObject.GetComponent<TurretShooting>();
        _turret.allReloadGun += StartShowingReload;
    }
    private void OnFire()
    {
        SetTurret();
        _turretShooting.shoot?.Invoke();
    }

    private void StartShowingReload(ShootGun gun)
    {
        _currentGun = gun;
        _reloadBG.gameObject.SetActive(true);
        StartCoroutine(UpdateReloadUI());
    }

    private IEnumerator UpdateReloadUI()
    {
        while (!_turret.isAnyWeaponReady)
        {
            if (_currentGun != null)
            {
                _reloadText.text = $"{Mathf.CeilToInt(_currentGun.curretnReloadTime)}";
            }
            yield return null;
        }
        _reloadBG.gameObject.SetActive(false);
        _reloadText.text = "";
        _currentGun = null;
    }
}

