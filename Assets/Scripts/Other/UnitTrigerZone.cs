using UnityEngine;


public class UnitTrigerZone : MonoBehaviour
{
    [SerializeField] private GameObject _targetForUnit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit")
        {
            Debug.Log(other.name);
            MoveUnit unit = other.GetComponent<MoveUnit>();
           unit.startMoveToTarget?.Invoke(_targetForUnit);
        }
    }
}

