using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Screens;

namespace Asteroids.Presenters.Screens
{
    public class GameScreenPresenter : BaseScreenPresenter<GameScreenData,IGameScreenView>
    {
        public GameScreenPresenter(EnvironmentData environmentData, GameScreenData data, IGameScreenView view) : base(environmentData, data, view)
        {
        }

        public override void Attach()
        {
            base.Attach();
            
            _data.OnSetLaserReloadMarker += _view.SetLaserReloadMarker;
            _data.OnSetBulletReloadMarker += _view.SetBulletReloadMarker;
            _environmentData.ScoreData.OnSetCurrentScore += _view.SetCurrentScore;
            _environmentData.ShipData.OnDamage += _view.SetCurrentHp;
            _environmentData.ScoreData.OnSetMaxScore += _view.SetMaxScore;
        }

        public override void Detach()
        {
            base.Detach();
            _data.OnSetLaserReloadMarker -= _view.SetLaserReloadMarker;
            _data.OnSetBulletReloadMarker -= _view.SetBulletReloadMarker;
            _environmentData.ScoreData.OnSetCurrentScore -= _view.SetCurrentScore;
            _environmentData.ShipData.OnDamage -= _view.SetCurrentHp;
            _environmentData.ScoreData.OnSetMaxScore -= _view.SetMaxScore;
        }

        protected override void Show()
        {
            _view.SetMaxHp(_environmentData.ShipData.ShipDescription.Hp);
            _view.SetCurrentHp(_environmentData.ShipData.ShipDescription.Hp);
            base.Show();
        }
    }
}