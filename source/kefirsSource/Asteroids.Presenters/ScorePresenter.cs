﻿using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data;

namespace Asteroids.Presenters
{
    public class ScorePresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly ScoreData _data;
        private readonly Timer _timer = new Timer(1, true);

        public ScorePresenter(EnvironmentData environmentData, ScoreData data)
        {
            _environmentData = environmentData;
            _data = data;
        }

        public void Attach()
        {
            _data.SetMaxScore(_environmentData.SaveModel.Get<int>("MaxScore"));
            _environmentData.EnemyData.EnemyFactoryData.OnKill += AddKillScore;
            _timer.OnNotify += AddTimeScore;
            _environmentData.TimerCollection.Add(_timer);
        }

        public void Detach()
        {
            _data.KillScore = 0;
            _data.TimeScore = 0;
            _environmentData.EnemyData.EnemyFactoryData.OnKill -= AddKillScore;
            _timer.OnNotify -= AddTimeScore;
            _environmentData.TimerCollection.Remove(_timer);
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
                _environmentData.SaveModel.Set("MaxScore", _data.MaxScore);
            }
        }
    }
}