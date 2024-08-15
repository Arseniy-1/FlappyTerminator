using System;
using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour, ISpawnable, IInteractable
{
    public event Action<ISpawnable> OnDisabled;

    public void RaiseOnDisabled()
    {
        OnDisabled?.Invoke(this);
    }

    public abstract void Disable();
}
