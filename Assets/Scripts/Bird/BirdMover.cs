using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : Mover
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Quaternion _maxRortation;
    private Quaternion _minRortation;

    private void Start()
    {
        _startPosition = transform.position;

        _maxRortation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRortation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRortation, _rotationSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        Rigidbody2D.velocity = new Vector2(Speed, _tapForce);
        transform.rotation = _maxRortation;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        Rigidbody2D.velocity = Vector2.zero;
    }
}
