using System;

public interface ISpawnable
{
    public event Action<ISpawnable> OnDisabled;

    void Disable();
}
