using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Data.Enemies;

namespace Asteroids.Presenters.Enemies
{
    public class EnemyPresenter : IPresenter
    {
        private readonly EnemyData _data;
        private readonly Environment _environment;
        private readonly EnemyFactoryPresenter _factory;
        private readonly Timer _spawnTimer;

        public EnemyPresenter(Environment environment, EnemyData data)
        {
            _environment = environment;
            _data = data;
            _factory = new EnemyFactoryPresenter(_environment, _data.EnemyFactoryData);
            _spawnTimer = new Timer(1f / _data.EnemyDescription.SpawnRate, true);
        }

        public void Attach()
        {
            _data.OnUpdate += Update;
            _factory.Attach();
            _spawnTimer.OnNotify += Create;
            _environment.CollectionContainer.TimerCollection.Add(_spawnTimer);
        }

        public void Detach()
        {
            _data.OnUpdate -= Update;
            _factory.Detach();
            _spawnTimer.OnNotify -= Create;
            _environment.CollectionContainer.TimerCollection.Remove(_spawnTimer);
        }

        private void Update()
        {
            _data.EnemyFactoryData.Update();
            foreach (var subEnemyData in _data.EnemyFactoryData.SubEnemyDatas) subEnemyData.Update();
        }

        private void Create()
        {
            var enemyId =
                _environment.EnvironmentData.Random.Next(_data.EnemyDescription.AlienChance +
                                                         _data.EnemyDescription.AsteroidChance);
            if (enemyId < _data.EnemyDescription.AlienChance)
                _data.EnemyFactoryData.Generate(EnemyType.Alien);
            else
                _data.EnemyFactoryData.Generate(EnemyType.Asteroid);
        }
    }
}