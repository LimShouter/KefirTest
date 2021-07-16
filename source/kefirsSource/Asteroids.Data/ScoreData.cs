using System;

namespace Asteroids.Data
{
    public class ScoreData
    {
        public event Action<int> OnSetCurrentScore;
        public event Action<int> OnSetMaxScore;

        public readonly int TimeScoreMultiplier;
        public readonly int KillScoreMultiplier;
        
        public int MaxScore;
        public int TimeScore;
        public int KillScore;
        private int _currentScore;

        public ScoreData(int timeScoreMultiplier, int killScoreMultiplier)
        {
            TimeScoreMultiplier = timeScoreMultiplier;
            KillScoreMultiplier = killScoreMultiplier;
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