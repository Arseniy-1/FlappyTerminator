using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    [SerializeField] private Flappy _flappy;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private Spawner<Enemy> _enemySpawner;
    [SerializeField] private Spawner<Coin> _coinSpawner;
    [SerializeField] private Spawner<Food> _foodSpawner;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _flappy.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _flappy.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        _endGameScreen.Open();
        _flappy.Disable();
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _flappy.Enable();
        Clear();
    }

    private void Clear()
    {
        _enemySpawner.Clear();
        _foodSpawner.Clear();
        _coinSpawner.Clear();
    }
}
