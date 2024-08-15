using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealthPoint;

    public event Action<float, float> HealthChanged;
    public event Action CriticalHealthLevelReached;

    private void OnValidate()
    {
        _currentHealthPoint = _maxHealth;
    }

    public void Heal(float amount)
    {
        if (amount <= 0)
            return;

        _currentHealthPoint = Mathf.Clamp(_currentHealthPoint + amount, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealthPoint, _maxHealth);
    }

    public void Reset()
    {
        _currentHealthPoint = _maxHealth;
        HealthChanged?.Invoke(_currentHealthPoint, _maxHealth);
    }

    public void TakeDamage(float amount)
    {
        if (amount <= 0)
            return;

        _currentHealthPoint = Mathf.Clamp(_currentHealthPoint - amount, 0, _maxHealth);

        if (_currentHealthPoint == 0)
        {
            CriticalHealthLevelReached?.Invoke();
        }

        HealthChanged?.Invoke(_currentHealthPoint, _maxHealth);
    }
}
