using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data;

namespace Asteroids.Presenters
{
    public class ScorePresenter : IPresenter
    {
        private readonly ScoreData _data;
        private readonly Environment _environment;
        private readonly Timer _timer = new Timer(1, true);

        public ScorePresenter(Environment environment, ScoreData data)
        {
            _environment = environment;
            _data = data;
        }

        public void Attach()
        {
            _data.KillScore = 0;
            _data.TimeScore = 0;
            _data.SetMaxScore(_environment.EnvironmentData.SaveModel.Get<int>("MaxScore"));
            _environment.EnvironmentData.EnemyData.EnemyFactoryData.OnKill += AddKillScore;
            _timer.OnNotify += AddTimeScore;
            _environment.CollectionContainer.TimerCollection.Add(_timer);
        }

        public void Detach()
        {
            _environment.EnvironmentData.EnemyData.EnemyFactoryData.OnKill -= AddKillScore;
            _timer.OnNotify -= AddTimeScore;
            _environment.CollectionContainer.TimerCollection.Remove(_timer);
        }

        private void AddTimeScore()
        {
            _data.TimeScore += _data.ScoreDescription.TimeMultiplier;
            SetCurrentScore();
        }

        private void AddKillScore()
        {
            _data.KillScore += _data.ScoreDescription.KillMultiplier;
            SetCurrentScore();
        }

        private void SetCurrentScore()
        {
            _data.CurrentScore.Value = _data.TimeScore + _data.KillScore;
            var score = _data.CurrentScore.Value;
            if (score > _data.MaxScore.Value)
            {
                _data.SetMaxScore(score);
                _environment.EnvironmentData.SaveModel.Set("MaxScore", _data.MaxScore.Value);
            }
        }
    }
}