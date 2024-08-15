using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        _score.ScoreChanged += ShowScore;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= ShowScore;
    }

    private void ShowScore(int amount)
    {
        _scoreText.text = amount.ToString();    
    }
}
