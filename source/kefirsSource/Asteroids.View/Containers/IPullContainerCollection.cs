using Asteroids.View.ViewManagers;

namespace Asteroids.View.Containers
{
    public interface IPullContainerCollection
    {
        IPullContainer<ISubEnemyView> AlienPullContainer { get; }
        IPullContainer<ISubEnemyView> AsteroidPullContainer { get; }
        IPullContainer<ISubEnemyView> AsteroidPiecePullContainer { get; }
        IPullContainer<ISubShotView> ShotPullContainer { get; }
        IPullContainer<ISubShotView> LaserPullContainer { get; }
    }
}