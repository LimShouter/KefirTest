using Asteroids.View.ViewManagers;

namespace Asteroids.Core.Pull
{
    public class PullCollection
    {
        public readonly BasePull<ISubEnemyView> AlienPull = new BasePull<ISubEnemyView>();
        public readonly BasePull<ISubEnemyView> AsteroidPiecePull = new BasePull<ISubEnemyView>();
        public readonly BasePull<ISubEnemyView> AsteroidPull = new BasePull<ISubEnemyView>();
        public readonly BasePull<ISubShotView> LaserPull = new BasePull<ISubShotView>();
        public readonly BasePull<ISubShotView> ShotsPull = new BasePull<ISubShotView>();
    }
}