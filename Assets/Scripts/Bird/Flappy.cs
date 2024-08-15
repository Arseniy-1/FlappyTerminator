using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Flappy : MonoBehaviour, IInteractable, IHealable
{
    [SerializeField] private Gun _gun;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private InputHandler _inputHaldler;
    [SerializeField] private BirdCollisionHandler _birdCollisionHandler;
    [SerializeField] private Score _score;
    [SerializeField] private Health _health;

    public event Action GameOver;

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
        _health.CriticalHealthLevelReached += OnDied;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
        _health.CriticalHealthLevelReached -= OnDied;
    }

    private void Update()
    {
        if (_inputHaldler.IsShooting)
            _gun.Shoot();

        if (_inputHaldler.IsJumped)
            _birdMover.Jump();
    }

    public void Enable()
    {
        _birdMover.enabled = true;
        _gun.enabled = true;
        _inputHaldler.enabled = true;
    }

    public void Disable()
    {
        _birdMover.enabled = false;
        _gun.enabled = false;
        _inputHaldler.enabled = false;
    }

    public void Heal(float amount)
    {
        _health.Heal(amount);
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            OnDied();
        }

        if (interactable is Bound)
        {
            OnDied();
        }

        if (interactable is Coin coin)
        {
            _score.Add();
            coin.Disable();
        }

        if (interactable is Food food)
        {
            food.Disable();
            food.Heal(this);
        }
    }

    private void OnDied()
    {
        GameOver?.Invoke();
        _birdMover.Reset();
        _score.Reset();
        _health.Reset();
    }
}
