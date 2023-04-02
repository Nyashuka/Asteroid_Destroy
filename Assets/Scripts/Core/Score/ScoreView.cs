using UnityEngine;
using UnityEngine.UI;

namespace Core.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        private global::Score _score;

        public void Init(global::Score score )
        {
            _score = score;
            _score.ScoreChangedEvent += OnScoreChanged;
        }

        private void OnScoreChanged(int newScore)
        {
            scoreText.text = newScore.ToString();
        }

        private void OnDestroy()
        {
            _score.ScoreChangedEvent -= OnScoreChanged;
        }
    }
}

