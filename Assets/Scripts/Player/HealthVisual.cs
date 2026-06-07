using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HealthVisual : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Health _healthPref;
    [SerializeField] private Canvas _canvas;

    private float _distance = 0;

    private List<Health> _healths;

    private void Awake()
    {
        _healths = new List<Health>();
    }

    private void Start()
    {
        for (int i = 0; i < _health.Max; i++)
        {
            Health healthPref = Instantiate(_healthPref);
            healthPref.transform.SetParent(_canvas.transform);
            healthPref.transform.position = new Vector2(-8.4f, 4.5f);
            healthPref.transform.position += new Vector3(_distance, 0,0);
            _healths.Add(healthPref);
            _distance += 1;
        }

        Debug.Log(_healths.Count);
    }

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable() 
    {
        _health.Changed -= OnHealthChanged;
    } 

    private void OnHealthChanged(float current)
    {
        int targetCount = Mathf.Max(0, (int)current);

        while (_healths.Count > targetCount)
        {
            int lastIndex = _healths.Count - 1;

            if (lastIndex < 0)
                break;

            Destroy(_healths[lastIndex].gameObject);
            _healths.RemoveAt(lastIndex);
        }
    }

}
