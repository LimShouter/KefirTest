using Asteroids.Core;
using Asteroids.Data.Enemies;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Enemies
{
    public class AsteroidEnemyPresenter : BaseEnemyPresenter
    {
        public AsteroidEnemyPresenter(Environment environment, SubEnemyData data, ISubEnemyView view) : base(
            environment, data, view)
        {
        }

        protected override void Update()
        {
            base.Update();
            _data.Position = _view.Move(_data.Direction, _data.Speed);
        }
    }
}