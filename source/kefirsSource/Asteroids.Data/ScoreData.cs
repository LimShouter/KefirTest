using System;
using Asteroids.Description;

namespace Asteroids.Data
{
    public class ScoreData
    {
        public readonly ScoreDescription ScoreDescription;
        public event Action<int> OnSetCurrentScore;
        public event Action<int> OnSetMaxScore;

        
        public int MaxScore;
        public int TimeScore;
        public int KillScore;
        public int CurrentScore;

        public ScoreData(ScoreDescription scoreDescription)
        {
            ScoreDescription = scoreDescription;
        }

        public void SetCurrentScore()
        {
            OnSetCurrentScore?.Invoke(CurrentScore);
        }

        public void SetMaxScore(int obj)
        {
            MaxScore = obj;
            OnSetMaxScore?.Invoke(MaxScore);
        }
    }
}