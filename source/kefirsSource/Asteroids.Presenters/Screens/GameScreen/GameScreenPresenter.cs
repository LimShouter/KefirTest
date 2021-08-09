using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;

namespace Asteroids.Presenters.Screens.GameScreen
{
    public class GameScreenPresenter : BaseScreenPresenter<GameScreenData,IGameScreenView>
    {
        private readonly HealthObserver _healthObserver;
        private readonly ReloadObserver _reloadObserver;
        private readonly ScoreObserver _scoreObserver;
        public GameScreenPresenter(EnvironmentData environmentData, GameScreenData data, IGameScreenView view) : base(
            environmentData, data, view)
        {
            _healthObserver = new HealthObserver(_environmentData.ShipData.Hp,_environmentData.ShipData.ShipDescription.Hp,view.HealthView);
            _reloadObserver = new ReloadObserver(_environmentData.ShotData.LaserReload,
                _environmentData.ShotData.BulletReload, view.ReloadMarkerView);
            _scoreObserver = new ScoreObserver(environmentData.ScoreData.CurrentScore,
                environmentData.ScoreData.MaxScore, view.ScoreTextView);
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