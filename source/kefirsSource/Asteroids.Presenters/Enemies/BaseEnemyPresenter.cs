using Asteroids.Core;
using Asteroids.Data.Enemies;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Enemies
{
    public abstract class BaseEnemyPresenter : IPresenter
    {
        protected readonly SubEnemyData _data;
        protected readonly Environment _environment;
        protected readonly ISubEnemyView _view;

        protected BaseEnemyPresenter(Environment environment, SubEnemyData data, ISubEnemyView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.SetTransform(_data.Position, _data.Direction);
            _data.OnUpdate += Update;
            _view.OnKill += Kill;
            _view.Show();
        }

        public void Detach()
        {
            _environment.EnvironmentData.EnemyData.EnemyUpdater.OnUpdate -= Update;
            _view.OnKill -= Kill;
            _view.Hide();
        }

        private void Kill()
        {
            _environment.EnvironmentData.EnemyData.EnemyFactoryData.Kill();
            OnDestroy();
        }

        private void OnDestroy()
        {
            _environment.EnvironmentData.EnemyData.EnemyFactoryData.Destroy(_data);
        }


        protected virtual void Update()
        {
            if (_data.Position.X > _environment.EnvironmentData.SpawnAreas[0].XMax ||
                _data.Position.X < _environment.EnvironmentData.SpawnAreas[3].XMin ||
                _data.Position.Y > _environment.EnvironmentData.SpawnAreas[0].YMax ||
                _data.Position.Y < _environment.EnvironmentData.SpawnAreas[0].YMin) OnDestroy();
        }
    }
}