using Asteroids.Description;

namespace Asteroids.Data.Shot
{
    public class ShotData
    {
        public readonly ShotDescription ShotDescription;
        public readonly ShotFactoryData ShotFactoryData = new ShotFactoryData();
        public readonly Updater.Updater ShotUpdater = new Updater.Updater();
        public readonly ReactField<bool> LaserReload = new ReactField<bool>(); 
        public readonly ReactField<bool> BulletReload = new  ReactField<bool>(); 

        public ShotData(ShotDescription shotDescription)
        {
            ShotDescription = shotDescription;
        }
    }
}