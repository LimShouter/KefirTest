using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data.Enemies;

namespace Asteroids.Presenters.Enemies
{
    public class EnemyPresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly EnemyData _data;
        private readonly EnemyFactoryPresenter _factory;
        private readonly Timer _spawnTimer;

        public EnemyPresenter(EnvironmentData environmentData,EnemyData data)
        {
            _environmentData = environmentData;
            _data = data;
            _factory= new EnemyFactoryPresenter(_environmentData,_data.EnemyFactoryData);
            _spawnTimer = new Timer(1f / _data.EnemyDescription.SpawnRate, true);
        }
        
        public void Attach()
        {
            _data.EnemyUpdater.OnUpdate += Update;
            _factory.Attach();
            _spawnTimer.OnNotify += Create;
            _environmentData.TimerCollection.Add(_spawnTimer);
            _environmentData.UpdaterCollection.Add(_data.EnemyUpdater);
        }

        public void Detach()
        {
            _data.EnemyUpdater.OnUpdate -= Update;
            _factory.Detach();
            _spawnTimer.OnNotify -= Create;
            _environmentData.TimerCollection.Remove(_spawnTimer);
            _environmentData.UpdaterCollection.Remove(_data.EnemyUpdater);
        }

        private void Update()
        {
            _data.EnemyFactoryData.Update();
            foreach (var subEnemyData in _data.EnemyFactoryData.SubEnemyDatas)
            {
                subEnemyData.Update();
            }
        }

        private void Create()
        {
            
            var enemyId =_environmentData.Random.Next( _data.EnemyDescription.AlienChance + _data.EnemyDescription.AsteroidChance);
            if (enemyId < _data.EnemyDescription.AlienChance)
            {
                _data.EnemyFactoryData.Generate(EnemyType.Alien);
            }
            else
            {
                _data.EnemyFactoryData.Generate(EnemyType.Asteroid);
            }
        }
    }
}