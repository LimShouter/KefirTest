using System;
using Asteroids.Data.Enemies;
using Asteroids.View.ViewManagers;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Presenters.Enemies
{
    public class AlienEnemyPresenter : BaseEnemyPresenter
    {
        public AlienEnemyPresenter(Environment environment, SubEnemyData data, ISubEnemyView view) : base(environment,
            data, view)
        {
        }

        protected override void Update()
        {
            base.Update();
            var rotationZ = Math.Atan2(_environment.EnvironmentData.ShipData.Position.X - _data.Position.X,
                _environment.EnvironmentData.ShipData.Position.Y - _data.Position.Y);
            _data.Direction = (float)rotationZ;
            _data.Position = _view.Move(_data.Direction, _data.Speed);
        }
    }
}