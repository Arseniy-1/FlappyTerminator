using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Flappy _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        if (_bird != null)
        {
            Vector3 position = transform.position;
            position.x = _bird.transform.position.x + _xOffset;
            transform.position = position;
        }
    }
}
