using System.Collections.Generic;
using System.Net.NetworkInformation;
using Asteroids.Core.Pull.Pulls;
using Asteroids.Core.Time;
using Asteroids.Data;
using Asteroids.Data.Enemies;
using Asteroids.Data.Shot;
using Asteroids.Data.Updater;
using Asteroids.Description;
using Asteroids.View;
using Asteroids.View.Containers;

namespace Asteroids.Core
{
    public class EnvironmentData
    {
        public readonly ShotsPull ShotsPull = new ShotsPull();
        public readonly ShotsPull LaserPull = new ShotsPull();
        public readonly EnemyPull AsteroidPull = new EnemyPull();
        public readonly EnemyPull AsteroidPiecePull = new EnemyPull();
        public readonly EnemyPull AlienPull = new EnemyPull();

        public readonly GameManagerData GameManagerData = new GameManagerData();
        public readonly InputData InputData = new InputData();
        public readonly ShipData ShipData;
        public readonly ShotData ShotData;
        public readonly ScoreData ScoreData;
        public readonly EnemyData EnemyData;
        public readonly ScreenData ScreenData = new ScreenData();

        public readonly List<GameArea> SpawnAreas;
        public readonly GameArea GameArea;

        public readonly UpdaterCollection UpdaterCollection = new UpdaterCollection();
        public readonly TimerCollection TimerCollection = new TimerCollection();

        public readonly ICustomRandom Random;
        public readonly ISaveModel SaveModel;

        public EnvironmentData(DescriptionCollection descriptions, ISaveModel saveModel)
        {
            SaveModel = saveModel;
            Random = descriptions.CustomRandom;
            EnemyData = new EnemyData(descriptions.EnemyDescription);
            ShotData = new ShotData(descriptions.ShotDescription);
            ShipData = new ShipData(descriptions.ShipDescription);
            SpawnAreas = descriptions.SpawnAreas;
            GameArea = descriptions.GameArea;
            ScoreData = new ScoreData(descriptions.ScoreDescription);
        }
    }
}