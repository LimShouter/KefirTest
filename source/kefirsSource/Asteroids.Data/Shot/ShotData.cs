using Asteroids.Description;

namespace Asteroids.Data.Shot
{
    public class ShotData
    {
        public readonly ShotDescription ShotDescription;
        public readonly ShotFactoryData ShotFactoryData = new ShotFactoryData();
        public readonly Updater.Updater ShotUpdater = new Updater.Updater();

        public ShotData(ShotDescription shotDescription)
        {
            ShotDescription = shotDescription;
        }
    }
}