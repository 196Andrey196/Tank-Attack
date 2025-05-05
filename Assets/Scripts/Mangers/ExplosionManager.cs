using System;
using UnityEngine;


public class ExplosionManager : MonoBehaviour
{
    public static Action<Vector3> explosion;
    [SerializeField] private ParticleSystem _explosionEffect;
    void OnEnable()
    {
        explosion += PlayExplosion;
    }
    void OnDisable()
    {
        explosion -= PlayExplosion;
    }


    public void PlayExplosion(Vector3 position)
    {
        if (_explosionEffect == null) return;

        _explosionEffect.transform.position = position;
        _explosionEffect.gameObject.SetActive(true);
        _explosionEffect.Play();
        StartCoroutine(DisableAfterPlay());
    }

    private System.Collections.IEnumerator DisableAfterPlay()
    {
        yield return new WaitForSeconds(1f);
        _explosionEffect.gameObject.SetActive(false);
    }
}

