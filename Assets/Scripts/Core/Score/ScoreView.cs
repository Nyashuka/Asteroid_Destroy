
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Score _score;

    public void Start()
    {
        _score.ScoreChanged += OnScoreValueChanged;
    }

    private void OnScoreValueChanged(int newScore)
    {
        _scoreText.text = "Score: " + newScore.ToString();
    }
}

