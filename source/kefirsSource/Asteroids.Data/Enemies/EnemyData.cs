namespace Asteroids.Data.Enemies
{
    public class EnemyData
    {
        public readonly float MinSpeed;
        public readonly float MaxSpeed;
        public readonly float AlienSpeed;

        public readonly int AlienChance;
        public readonly int AsteroidChance;

        public readonly float SpawnRate;
        
        public readonly EnemyFactoryData EnemyFactoryData = new EnemyFactoryData();
        public readonly Updater.Updater EnemyUpdater = new Updater.Updater();

        public EnemyData(float minSpeed, float maxSpeed, float alienSpeed, int alienChance, int asteroidChance, float spawnRate)
        {
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
            AlienSpeed = alienSpeed;
            AlienChance = alienChance;
            AsteroidChance = asteroidChance;
            SpawnRate = spawnRate;
        }
    }
}