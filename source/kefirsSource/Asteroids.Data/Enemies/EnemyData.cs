using Asteroids.Description;

namespace Asteroids.Data.Enemies
{
    public class EnemyData
    {
        public readonly EnemyDescription EnemyDescription;
        public readonly EnemyFactoryData EnemyFactoryData = new EnemyFactoryData();
        public readonly Updater.Updater EnemyUpdater = new Updater.Updater();

        public EnemyData(EnemyDescription description)
        {
            EnemyDescription = description;
        }
    }
}