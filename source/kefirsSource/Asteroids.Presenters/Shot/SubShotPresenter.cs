using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data.Shot;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Shot
{
    public class SubShotPresenter : IPresenter
    {
        private readonly SubShotData _data;
        private readonly Environment _environment;
        private readonly Timer _timer;
        private readonly ISubShotView _view;

        public SubShotPresenter(Environment environment, SubShotData data, ISubShotView view)
        {
            _timer = new Timer(data.LifeTime, false);
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.SetPosition(_data.Position, _data.Rotation);
            _data.OnUpdate += Move;
            _view.OnDamage += Damage;
            _timer.OnNotify += Destroy;
            _environment.CollectionContainer.TimerCollection.Add(_timer);
            _view.Show();
        }

        public void Detach()
        {
            _data.OnUpdate -= Move;
            _view.OnDamage -= Damage;
            _timer.OnNotify -= Destroy;
            _environment.CollectionContainer.TimerCollection.Remove(_timer);
            _view.Hide();
        }

        private void Destroy()
        {
            _environment.EnvironmentData.ShotData.ShotFactoryData.Destroy(_data);
        }

        private void Damage()
        {
            _data.Hp--;
            if (_data.Hp <= 0) _environment.EnvironmentData.ShotData.ShotFactoryData.Destroy(_data);
        }

        private void Move()
        {
            _data.Position = _view.Move(_data.Type == ShotType.Bullet
                ? _environment.EnvironmentData.ShotData.ShotDescription.BulletSpeed
                : _environment.EnvironmentData.ShotData.ShotDescription.LaserSpeed);
        }
    }
}