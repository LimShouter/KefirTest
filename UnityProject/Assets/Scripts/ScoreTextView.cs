using Asteroids.View.ViewManagers.Screens.GameScreenView;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreTextView : MonoBehaviour,IScoreTextView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI maxScoreText;
        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void SetMaxScore(int maxScore)
        {
            maxScoreText.text = maxScore.ToString();
        }
    }
}