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
        private int _currentScore;

        public ScoreData(ScoreDescription scoreDescription)
        {
            ScoreDescription = scoreDescription;
        }

        public int SetCurrentScore()
        {
            _currentScore = TimeScore + KillScore;
            OnSetCurrentScore?.Invoke(_currentScore);
            return _currentScore;
        }

        public void SetMaxScore(int obj)
        {
            MaxScore = obj;
            OnSetMaxScore?.Invoke(MaxScore);
        }
    }
}