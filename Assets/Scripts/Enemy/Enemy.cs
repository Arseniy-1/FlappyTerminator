using System.Collections;
using UnityEngine;

public class Enemy : SpawnableObject
{
    [SerializeField] private Gun _gun;
    [SerializeField] private Health _health;
    [SerializeField] private float _reloadTime;

    private Coroutine _shooting;

    private void OnEnable()
    {
        _health.CriticalHealthLevelReached += Disable;
        Reset();
    }

    private void OnDisable()
    {
        _health.CriticalHealthLevelReached -= Disable;
    }

    public override void Disable()
    {
        _health.Reset();

        if (_shooting != null)
            StopCoroutine(_shooting);

        RaiseOnDisabled();
    }

    public void Reset()
    {
        if (_shooting != null)
            StopCoroutine(_shooting);

        _shooting = StartCoroutine(Shooting());
    }
    
    private IEnumerator Shooting()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_reloadTime);
            _gun.Shoot();
        }
    }
}