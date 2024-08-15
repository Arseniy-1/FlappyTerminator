using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Spawner<T> : MonoBehaviour where T : SpawnableObject
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool<T> _pool;

    private List<SpawnableObject> _spawnables = new List<SpawnableObject>();

    private void Start()
    {
        StartCoroutine(GeneratingEnemys());
    }

    private IEnumerator GeneratingEnemys()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
            Spawn();
        }
    }

    public void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        T obj = _pool.Get();
        obj.OnDisabled += PlaceInPool;

        _spawnables.Add(obj);
        obj.transform.position = spawnPoint;
    }

    public void PlaceInPool(ISpawnable spawnable)
    {
        spawnable.OnDisabled -= PlaceInPool;
        _pool.Release((T)spawnable);
    }

    public void Clear()
    {
        foreach (SpawnableObject obj in _spawnables)
            obj.Disable();
    }
}
