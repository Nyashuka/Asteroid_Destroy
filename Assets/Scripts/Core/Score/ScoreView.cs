using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private Score _score;

    public void Init(Score score )
    {
        _score = score;
        _score.ScoreChangedEvent += OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }

    private void OnDestroy()
    {
        _score.ScoreChangedEvent -= OnScoreChanged;
    }
}

