using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data.Shot;

namespace Asteroids.Presenters.Shot
{
    public class ShotPresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly ShotData _data;
        private readonly ShotFactoryPresenter _factory;
        private readonly Timer _bulletReloadTimer;
        private readonly Timer _laserReloadTimer;
        

        public ShotPresenter(EnvironmentData environmentData,ShotData data)
        {
            _environmentData = environmentData;
            _data = data;
            _bulletReloadTimer = new Timer(1f / _data.ShotDescription.FireRate, true);
            _laserReloadTimer = new Timer(1f / _data.ShotDescription.BlastRate, true);
            _factory = new ShotFactoryPresenter(_environmentData,_data.ShotFactoryData);
        }
        
        public void Attach()
        {
            _factory.Attach();
            _bulletReloadTimer.OnNotify += BulletReload;
            _laserReloadTimer.OnNotify += LaserReload;
            _data.ShotUpdater.OnUpdate += Update;
            _environmentData.InputData.OnFire += Fire;
            _environmentData.InputData.OnBlast += Blast;
            _environmentData.TimerCollection.Add(_bulletReloadTimer);
            _environmentData.TimerCollection.Add(_laserReloadTimer);
            _environmentData.UpdaterCollection.Add(_data.ShotUpdater);
        }

        public void Detach()
        {
            _factory.Detach();
            _data.ShotUpdater.OnUpdate -= Update;
            _bulletReloadTimer.OnNotify -= BulletReload;
            _laserReloadTimer.OnNotify -= BulletReload;
            _environmentData.InputData.OnFire -= Fire;
            _environmentData.InputData.OnBlast -= Blast;
            _environmentData.UpdaterCollection.Remove(_data.ShotUpdater);
            _environmentData.TimerCollection.Remove(_bulletReloadTimer);
            _environmentData.TimerCollection.Remove(_laserReloadTimer);
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
            foreach (var subShotData in _data.ShotFactoryData.SubShotDatas)
            {
                subShotData.Update();
            }
        }

        private void BulletReload()
        {
            _data.BulletReload.Value = true;
        }
    }
}