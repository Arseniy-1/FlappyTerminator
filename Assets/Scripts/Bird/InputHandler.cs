using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private KeyCode _shootButton = KeyCode.E;
    private KeyCode _jumpButton = KeyCode.Space;

    public bool IsJumped { get; private set; } = false;
    public bool IsShooting { get; private set; } = false;

    private void Update()
    {
        if (Input.GetKeyDown(_shootButton))
            IsShooting = true;
        else
            IsShooting = false;

        if (Input.GetKey(_jumpButton))
            IsJumped = true;
        else
            IsJumped = false;
    }
}
