using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data.Shot;
using Asteroids.View;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Shot
{
    public class SubShotPresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly SubShotData _data;
        private readonly ISubShotView _view;
        private readonly Timer _timer;

        public SubShotPresenter(EnvironmentData environmentData,SubShotData data,ISubShotView view)
        {
            _timer = new Timer(data.LifeTime,false);
            _environmentData = environmentData;
            _data = data;
            _view = view;
        }
        
        public void Attach()
        {
            _view.SetPosition(_data.Position,_data.Rotation);
            _data.OnUpdate += Move;
            _view.OnDamage += Damage;
            _timer.OnNotify += Destroy;
            _environmentData.TimerCollection.Add(_timer);
            _view.Show();
        }

        public void Detach()
        {
            _data.OnUpdate -= Move;
            _view.OnDamage -= Damage;
            _timer.OnNotify -= Destroy;
            _environmentData.TimerCollection.Remove(_timer);
            _view.Hide();
        }

        private void Destroy()
        {
            _environmentData.ShotData.ShotFactoryData.Destroy(_data);
        }

        private void Damage()
        {
            _data.Hp--;
            if (_data.Hp <= 0)
            {
                _environmentData.ShotData.ShotFactoryData.Destroy(_data);
            }
        }

        private void Move()
        {
            _data.Position = _view.Move(_data.Type == ShotType.Bullet?_environmentData.ShotData.ShotDescription.BulletSpeed:_environmentData.ShotData.ShotDescription.LaserSpeed);
        }
    }
}