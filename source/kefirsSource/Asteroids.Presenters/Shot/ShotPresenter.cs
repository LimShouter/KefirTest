using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data.Shot;

namespace Asteroids.Presenters.Shot
{
    public class ShotPresenter : IPresenter
    {
        private readonly Timer _bulletReloadTimer;
        private readonly ShotData _data;
        private readonly Environment _environment;
        private readonly ShotFactoryPresenter _factory;
        private readonly Timer _laserReloadTimer;


        public ShotPresenter(Environment environment, ShotData data)
        {
            _environment = environment;
            _data = data;
            _bulletReloadTimer = new Timer(1f / _data.ShotDescription.FireRate, true);
            _laserReloadTimer = new Timer(1f / _data.ShotDescription.BlastRate, true);
            _factory = new ShotFactoryPresenter(environment, _data.ShotFactoryData);
        }

        public void Attach()
        {
            _factory.Attach();
            _bulletReloadTimer.OnNotify += BulletReload;
            _laserReloadTimer.OnNotify += LaserReload;
            _data.OnUpdate += Update;
            _environment.EnvironmentData.InputData.OnFire += Fire;
            _environment.EnvironmentData.InputData.OnBlast += Blast;
            _environment.CollectionContainer.TimerCollection.Add(_bulletReloadTimer);
            _environment.CollectionContainer.TimerCollection.Add(_laserReloadTimer);
        }

        public void Detach()
        {
            _factory.Detach();
            _data.OnUpdate -= Update;
            _bulletReloadTimer.OnNotify -= BulletReload;
            _laserReloadTimer.OnNotify -= BulletReload;
            _environment.EnvironmentData.InputData.OnFire -= Fire;
            _environment.EnvironmentData.InputData.OnBlast -= Blast;
            _environment.CollectionContainer.TimerCollection.Remove(_bulletReloadTimer);
            _environment.CollectionContainer.TimerCollection.Remove(_laserReloadTimer);
        }

        private void Blast()
        {
            if (_data.LaserReload.Value)
            {
                _data.ShotFactoryData.Create(ShotType.Laser);
                _laserReloadTimer.Reset();
            }

            _data.LaserReload.Value = false;
        }

        private void LaserReload()
        {
            _data.LaserReload.Value = true;
        }

        private void Fire()
        {
            if (_data.BulletReload.Value)
            {
                _data.ShotFactoryData.Create(ShotType.Bullet);
                _bulletReloadTimer.Reset();
            }

            _data.BulletReload.Value = false;
        }

        private void Update()
        {
            _data.ShotFactoryData.Update();
            foreach (var subShotData in _data.ShotFactoryData.SubShotDatas) subShotData.Update();
        }

        private void BulletReload()
        {
            _data.BulletReload.Value = true;
        }
    }
}