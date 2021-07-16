using Asteroids.Core;
using Asteroids.Data.Enemies;
using Asteroids.View;

namespace Asteroids.Presenters.Enemies
{
    public abstract class BaseEnemyPresenter : IPresenter
    {
        protected readonly EnvironmentData _environmentData;
        protected readonly SubEnemyData _data;
        protected readonly ISubEnemyView _view;

        protected BaseEnemyPresenter(EnvironmentData environmentData,SubEnemyData data,ISubEnemyView view)
        {
            _environmentData = environmentData;
            _data = data;
            _view = view;
        }
        
        public void Attach()
        {
            _view.SetTransform(_data.Position,_data.Direction);
            _data.OnUpdate += Update;
            _view.OnKill += Kill;
            _view.Show();
        }

        public void Detach()
        {
            _environmentData.EnemyData.EnemyUpdater.OnUpdate -= Update ;
            _view.OnKill -= Kill;
            _view.Hide();
        }

        private void Kill()
        {
            _environmentData.EnemyData.EnemyFactoryData.Kill();
            OnDestroy();
        }

        private void OnDestroy()
        {
            _environmentData.EnemyData.EnemyFactoryData.Destroy(_data);
        }
        

        protected virtual void Update()
        {
            if(_data.Position.X>_environmentData.SpawnAreas[0].XMax || _data.Position.X<_environmentData.SpawnAreas[3].XMin||_data.Position.Y>_environmentData.SpawnAreas[0].YMax||_data.Position.Y<_environmentData.SpawnAreas[0].YMin)
            {
                OnDestroy();
            }
        }
    }
}