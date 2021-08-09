using Asteroids.View;
using Asteroids.View.Containers;
using Asteroids.View.ViewManagers;
using UnityEngine;

public class PullContainerCollection : MonoBehaviour,IPullContainerCollection
{
    [SerializeField] private EnemyPullContainer _alienPullContainer;
    [SerializeField] private EnemyPullContainer _asteroidPullContainer;
    [SerializeField] private EnemyPullContainer _asteroidPiecePullContainer;
    [SerializeField] private ShotPullContainer _shotPullContainer;
    [SerializeField] private ShotPullContainer _laserPullContainer;

    public IPullContainer<ISubEnemyView> AlienPullContainer => _alienPullContainer;
    public IPullContainer<ISubEnemyView> AsteroidPullContainer => _asteroidPullContainer;
    public IPullContainer<ISubEnemyView> AsteroidPiecePullContainer => _asteroidPiecePullContainer;
    public IPullContainer<ISubShotView> ShotPullContainer => _shotPullContainer;
    public IPullContainer<ISubShotView> LaserPullContainer => _laserPullContainer;
}