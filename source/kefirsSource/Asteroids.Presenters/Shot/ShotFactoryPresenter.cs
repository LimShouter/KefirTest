using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Data.Shot;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Shot
{
    public class ShotFactoryPresenter : IPresenter
    {
        private readonly ShotFactoryData _data;
        private readonly Environment _environment;

        private readonly Dictionary<SubShotData, SubShotPresenter> _presenters =
            new Dictionary<SubShotData, SubShotPresenter>();

        private readonly Dictionary<SubShotData, ISubShotView> _views = new Dictionary<SubShotData, ISubShotView>();

        public ShotFactoryPresenter(Environment environment, ShotFactoryData data)
        {
            _environment = environment;
            _data = data;
        }

        public void Attach()
        {
            _data.OnCreate += Create;
            _data.OnUpdate += Update;
        }

        public void Detach()
        {
            _data.OnUpdate -= Update;
            _data.OnCreate -= Create;
            Clear();
        }

        private void Clear()
        {
            _data.DeletedDatas.AddRange(_data.SubShotDatas);
            Update();
        }

        private void Update()
        {
            foreach (var data in _data.DeletedDatas) Destroy(data);

            _data.DeletedDatas.Clear();
        }

        private void Create(ShotType type)
        {
            var data = new SubShotData(_environment.EnvironmentData.ShipData.Position,
                _environment.EnvironmentData.ShipData.Rotation,
                type == ShotType.Bullet
                    ? _environment.EnvironmentData.ShotData.ShotDescription.BulletHp
                    : _environment.EnvironmentData.ShotData.ShotDescription.LaserHp,
                type == ShotType.Bullet
                    ? _environment.EnvironmentData.ShotData.ShotDescription.ShotLifeTime
                    : _environment.EnvironmentData.ShotData.ShotDescription.LaserLifeTime,
                type);
            _data.SubShotDatas.Add(data);
            var pull = type == ShotType.Bullet
                ? _environment.PullCollection.ShotsPull
                : _environment.PullCollection.LaserPull;
            var view = pull.Get();
            _views.Add(data, view);
            var presenter = new SubShotPresenter(_environment, data, view);
            presenter.Attach();
            _presenters.Add(data, presenter);
        }


        private void Destroy(SubShotData data)
        {
            if (_data.SubShotDatas.Contains(data))
            {
                _presenters[data].Detach();
                _presenters.Remove(data);
                var pull = data.Type == ShotType.Bullet
                    ? _environment.PullCollection.ShotsPull
                    : _environment.PullCollection.LaserPull;
                pull.Put(_views[data]);
                _views.Remove(data);
                _data.SubShotDatas.Remove(data);
            }
        }
    }
}