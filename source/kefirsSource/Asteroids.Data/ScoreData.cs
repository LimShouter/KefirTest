using System;
using Asteroids.Description;

namespace Asteroids.Data
{
    public class ScoreData
    {
        public readonly ScoreDescription ScoreDescription;


        public int TimeScore;
        public int KillScore;
        public readonly ReactField<int> MaxScore  = new ReactField<int>();
        public readonly ReactField<int> CurrentScore = new ReactField<int>();

        public ScoreData(ScoreDescription scoreDescription)
        {
            ScoreDescription = scoreDescription;
        }

        public void SetMaxScore(int obj)
        {
            MaxScore.Value = obj;
        }
    }
}