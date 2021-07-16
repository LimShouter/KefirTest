namespace Asteroids.View
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