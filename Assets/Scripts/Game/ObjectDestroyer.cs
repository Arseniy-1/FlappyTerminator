using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ISpawnable returnable))
        {
            returnable.Disable();
        }
    }
}
