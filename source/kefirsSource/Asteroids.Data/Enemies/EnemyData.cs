using System;
using Asteroids.Description;

namespace Asteroids.Data.Enemies
{
    public class EnemyData
    {
        public event Action OnUpdate;
        public readonly EnemyDescription EnemyDescription;
        public readonly EnemyFactoryData EnemyFactoryData = new EnemyFactoryData();

        public EnemyData(EnemyDescription description)
        {
            EnemyDescription = description;
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}