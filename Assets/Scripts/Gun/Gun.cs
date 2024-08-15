using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    [SerializeField] protected ShootPoint ShootPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private  ObjectPool<Bullet> _pool;

    public void PlaceInPool(ISpawnable returnable)
    {
        returnable.OnDisabled -= PlaceInPool;
        _pool.Release((Bullet)returnable);
    }

    public void Shoot()
    {
        Bullet bullet = _pool.Get();
        bullet.Initialize(_enemyLayer);

        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        bullet.Activate();
        bullet.OnDisabled += PlaceInPool;
    }
}
