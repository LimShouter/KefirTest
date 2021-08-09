using Asteroids.Description;

namespace Asteroids.Data
{
    public class ScoreData
    {
        public readonly ReactField<int> CurrentScore = new ReactField<int>();
        public readonly ReactField<int> MaxScore = new ReactField<int>();
        public readonly ScoreDescription ScoreDescription;
        public int KillScore;


        public int TimeScore;

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