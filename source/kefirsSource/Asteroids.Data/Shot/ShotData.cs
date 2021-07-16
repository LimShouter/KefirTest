namespace Asteroids.Data.Shot
{
    public class ShotData
    {
        public readonly float BulletSpeed;
        public readonly float LaserSpeed;
        public readonly float FireRate;
        public readonly float LaserRate;
        public readonly float ShotLifeTime;
        public readonly float LaserLifeTime;
        public readonly int LaserHp;
        public readonly int BulletHp;

        public readonly ShotFactoryData ShotFactoryData = new ShotFactoryData();
        public readonly Updater.Updater ShotUpdater = new Updater.Updater();

        public ShotData(float bulletSpeed, float laserSpeed, float fireRate, float laserRate, int bulletHp, int laserHp, float shotLifeTime, float laserLifeTime)
        {
            BulletSpeed = bulletSpeed;
            FireRate = fireRate;
            LaserHp = laserHp;
            ShotLifeTime = shotLifeTime;
            LaserLifeTime = laserLifeTime;
            LaserSpeed = laserSpeed;
            BulletHp = bulletHp;
            LaserRate = laserRate;
        }
    }
}