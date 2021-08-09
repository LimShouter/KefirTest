using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Data.Shot;
using Asteroids.View;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Shot
{
    public class ShotFactoryPresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly ShotFactoryData _data;
        private readonly Dictionary<SubShotData, ISubShotView> _views = new Dictionary<SubShotData, ISubShotView>();

        private readonly Dictionary<SubShotData, SubShotPresenter> _presenters =
            new Dictionary<SubShotData, SubShotPresenter>();

        public ShotFactoryPresenter(EnvironmentData environmentData, ShotFactoryData data)
        {
            _environmentData = environmentData;
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
            foreach (var data in _data.DeletedDatas)
            {
                Destroy(data);
            }

            _data.DeletedDatas.Clear();
        }

        private void Create(ShotType type)
        {
            var data = new SubShotData(_environmentData.ShipData.Position, _environmentData.ShipData.Rotation,
                type == ShotType.Bullet ? _environmentData.ShotData.ShotDescription.BulletHp : _environmentData.ShotData.ShotDescription.LaserHp,
                type == ShotType.Bullet ? _environmentData.ShotData.ShotDescription.ShotLifeTime : _environmentData.ShotData.ShotDescription.LaserLifeTime,
                type);
            _data.SubShotDatas.Add(data);
            var pull = type == ShotType.Bullet ? _environmentData.ShotsPull : _environmentData.LaserPull;
            var view = pull.Get();
            _views.Add(data, view);
            var presenter = new SubShotPresenter(_environmentData, data, view);
            presenter.Attach();
            _presenters.Add(data, presenter);
        }


        private void Destroy(SubShotData data)
        {
            if (_data.SubShotDatas.Contains(data))
            {
                _presenters[data].Detach();
                _presenters.Remove(data);
                var pull = data.Type == ShotType.Bullet ? _environmentData.ShotsPull : _environmentData.LaserPull;
                pull.Put(_views[data]);
                _views.Remove(data);
                _data.SubShotDatas.Remove(data);
            }
        }
    }
}