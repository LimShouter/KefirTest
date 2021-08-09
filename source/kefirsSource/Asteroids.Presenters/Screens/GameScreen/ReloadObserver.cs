using Asteroids.Core;
using Asteroids.Data;
using Asteroids.View.ViewManagers.Screens.GameScreenView;

namespace Asteroids.Presenters.Screens.GameScreen
{
    public class ReloadObserver : IObserver
    {
        private readonly ReactField<bool> _laserReload;
        private readonly ReactField<bool> _bulletReload;
        private readonly IReloadMarkerView _view;

        public ReloadObserver(ReactField<bool> laserReload,ReactField<bool> bulletReload,IReloadMarkerView view)
        {
            _laserReload = laserReload;
            _bulletReload = bulletReload;
            _view = view;
        }
        public void Activate()
        {
            _laserReload.OnNotifyChanged += _view.SetLaserMarker;
            _bulletReload.OnNotifyChanged += _view.SetBulletMarker;
        }

        public void Deactivate()
        {
            _laserReload.OnNotifyChanged -= _view.SetLaserMarker;
            _bulletReload.OnNotifyChanged -= _view.SetBulletMarker;
        }
    }
}