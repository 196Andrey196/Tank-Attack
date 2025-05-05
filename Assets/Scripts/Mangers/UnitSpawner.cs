using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pointList;
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private float _countdownSpawn;
    private PoolManager _unitPool;

    void Start()
    {
        _unitPool = new PoolManager(_unitPrefab, 10, transform);
        StartCoroutine(SpawnUnits());
    }

    private IEnumerator SpawnUnits()
    {
        while (true)
        {
            foreach (var point in _pointList)
            {
                GameObject unit = _unitPool.GetObject(point.transform);
                unit.transform.localPosition = point.transform.position;  
                unit.transform.localRotation = point.transform.rotation;  


                yield return new WaitForSeconds(_countdownSpawn);
            }
        }
    }

}

