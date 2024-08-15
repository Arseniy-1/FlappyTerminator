using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : SpawnableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private LayerMask _layer;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_layer & (1 << collision.gameObject.layer)) != 0)
        {
            if (collision.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
                Disable();
            }
        }
    }

    public void Initialize(LayerMask layerMask)
    {
        _layer = layerMask;
    }

    public override void Disable()
    {
        RaiseOnDisabled();
    }

    public void Activate()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }
}
