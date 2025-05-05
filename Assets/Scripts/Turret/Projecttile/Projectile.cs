using System.Collections;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float _detoneteTime;
    [SerializeField] private AudioClip _explosionSound;


    void OnEnable()
    {
        StartCoroutine(DetonateTimer());
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private IEnumerator DetonateTimer()
    {
        yield return new WaitForSeconds(_detoneteTime);
        ExplosionManager.explosion?.Invoke(transform.position);
        SoundManager.playEffect?.Invoke(_explosionSound,0.1f);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit" || other.tag == "Turret")
        {
            ITakeDamage damageCalculator = other.GetComponent<ITakeDamage>();
            damageCalculator?.TakeDamage();
            ExplosionManager.explosion?.Invoke(transform.position);
            SoundManager.playEffect?.Invoke(_explosionSound,0.1f);
            gameObject.SetActive(false);
        }
    }
}

