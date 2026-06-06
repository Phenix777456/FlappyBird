using System;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private string _name;
    [SerializeField] private float _current;

    public float Current => _current;
    public float Max => _max;

    public event Action Deaded;

    public event Action<float> Changed;

    public void Decreace(float damage)
    {

        _current -= damage;
        Changed?.Invoke(_current);


        if (_current <= 0)
            Deaded?.Invoke();

        Debug.Log($"Здоровье {_name}: {_current}");
    }
}
