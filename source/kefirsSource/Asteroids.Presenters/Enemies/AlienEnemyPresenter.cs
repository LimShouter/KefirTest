using System;
using Asteroids.Core;
using Asteroids.Data.Enemies;
using Asteroids.View;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Enemies
{
    public class AlienEnemyPresenter : BaseEnemyPresenter
    {
        public AlienEnemyPresenter(EnvironmentData environmentData, SubEnemyData data, ISubEnemyView view) : base(environmentData, data, view)
        {
        }

        protected override void Update()
        { 
            base.Update();
            var rotationZ = Math.Atan2(_environmentData.ShipData.Position.X - _data.Position.X,
                _environmentData.ShipData.Position.Y - _data.Position.Y);
            _data.Direction = (float) rotationZ;
            _data.Position =_view.Move(_data.Direction,_data.Speed);
        }
    }
}