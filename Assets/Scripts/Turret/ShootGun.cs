using System.Collections;
using UnityEngine;


public class ShootGun : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _projectailePrefab;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _curretnReloadTime;
    public float curretnReloadTime { get { return _curretnReloadTime; } }
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private bool _canShoot;
    public bool canShoot { get { return _canShoot; } }

    private PoolManager _projectailPool;
    void Start()
    {
        _projectailPool = new PoolManager(_projectailePrefab, 5, _firePoint);
        _canShoot = true;
    }
    public void OnShoot()
    {
        if (_canShoot == true)
        {
            SoundManager.playEffect?.Invoke(_fireSound,0.2f);
            GameObject projectile = _projectailPool.GetObject(_firePoint);
            projectile.transform.rotation = Quaternion.Euler(_projectailePrefab.transform.rotation.eulerAngles.x, _firePoint.rotation.eulerAngles.y, _firePoint.rotation.eulerAngles.z);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(projectile.transform.forward * _shootForce, ForceMode.Impulse);
            _canShoot = false;
            StartCoroutine(ReloadGun());
        }
    }
    private IEnumerator ReloadGun()
    {
        _curretnReloadTime = _reloadTime;

        while (_curretnReloadTime > 0f)
        {
            _curretnReloadTime -= Time.deltaTime;
            yield return null;
        }

        _canShoot = true;
    }
}

