using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Data;
using Asteroids.Presenters.Enemies;
using Asteroids.Presenters.Shot;

namespace Asteroids.Presenters
{
    public class GameManagerPresenter : IPresenter
    {
        private readonly GameManagerData _data;
        private readonly Environment _environment;
        private readonly IEnvironmentView _environmentView;
        private readonly List<IPresenter> _gamePresenters = new List<IPresenter>();
        private readonly StepExecutor _gameStepExecutor = new StepExecutor();

        public GameManagerPresenter(Environment environment, GameManagerData data,
            IEnvironmentView environmentView)
        {
            _environment = environment;
            _data = data;
            _environmentView = environmentView;
        }

        public void Attach()
        {
            _data.OnPlay += Play;
            _data.OnStop += Stop;
            _data.CurrentScreen = _environment.EnvironmentData.ScreenData.StartScreenData;
        }

        public void Detach()
        {
            _data.OnPlay += Play;
            _data.OnStop += Stop;
        }

        private void Play()
        {
            _gameStepExecutor.Add(new ShipStep());
            _gameStepExecutor.Add(new ShotStep());
            _gameStepExecutor.Add(new ScoreStep());
            _gameStepExecutor.Add(new InputStep());
            _gameStepExecutor.Add(new EnemyStep());
            _gameStepExecutor.Execute(_gamePresenters, _environment, _environmentView);
            foreach (var presenter in _gamePresenters) presenter.Attach();
            _data.CurrentScreen.Hide();
            _environment.EnvironmentData.ScreenData.GameScreenData.Show();
        }

        private void Stop()
        {
            _gameStepExecutor.Clear();
            foreach (var presenter in _gamePresenters) presenter.Detach();
            _gamePresenters.Clear();
            _data.CurrentScreen.Hide();
            _environment.EnvironmentData.ScreenData.RematchScreenData.Show();
        }
    }
}