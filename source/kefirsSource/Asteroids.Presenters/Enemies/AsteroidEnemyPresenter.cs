using Asteroids.Core;
using Asteroids.Data.Enemies;
using Asteroids.View;

namespace Asteroids.Presenters.Enemies
{
    public class AsteroidEnemyPresenter : BaseEnemyPresenter
    {
        public AsteroidEnemyPresenter(EnvironmentData environmentData, SubEnemyData data, ISubEnemyView view) : base(environmentData, data, view)
        {
        }

        protected override void Update()
        {
            base.Update();
            _data.Position = _view.Move(_data.Direction,_data.Speed);
        }
    }
}