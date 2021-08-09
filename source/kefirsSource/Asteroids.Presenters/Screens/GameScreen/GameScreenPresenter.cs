using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;

namespace Asteroids.Presenters.Screens.GameScreen
{
    public class GameScreenPresenter : BaseScreenPresenter<GameScreenData, IGameScreenView>
    {
        private readonly HealthObserver _healthObserver;
        private readonly ReloadObserver _reloadObserver;
        private readonly ScoreObserver _scoreObserver;

        public GameScreenPresenter(Environment environment, GameScreenData data, IGameScreenView view) : base(
            environment, data, view)
        {
            _healthObserver = new HealthObserver(environment.EnvironmentData.ShipData.Hp,
                environment.EnvironmentData.ShipData.ShipDescription.Hp, view.HealthView);
            _reloadObserver = new ReloadObserver(environment.EnvironmentData.ShotData.LaserReload,
                environment.EnvironmentData.ShotData.BulletReload, view.ReloadMarkerView);
            _scoreObserver = new ScoreObserver(environment.EnvironmentData.ScoreData.CurrentScore,
                environment.EnvironmentData.ScoreData.MaxScore, view.ScoreTextView);
        }

        public override void Attach()
        {
            base.Attach();
            _healthObserver.Activate();
            _reloadObserver.Activate();
            _scoreObserver.Activate();
        }

        public override void Detach()
        {
            _healthObserver.Deactivate();
            _reloadObserver.Deactivate();
            _scoreObserver.Deactivate();
            base.Detach();
        }
    }
}