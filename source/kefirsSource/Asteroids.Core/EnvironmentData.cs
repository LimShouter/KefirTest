﻿using System.Collections.Generic;
using Asteroids.Core.Pull.Pulls;
using Asteroids.Core.Time;
using Asteroids.Data;
using Asteroids.Data.Enemies;
using Asteroids.Data.Shot;
using Asteroids.Data.Updater;
using Asteroids.Description;
using Asteroids.View;

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

        public EnvironmentData(DescriptionCollection descriptions,ISaveModel saveModel)
        {
            SaveModel = saveModel;
            Random = descriptions.CustomRandom;
            EnemyData = new EnemyData(descriptions.EnemyDescription.MinSpeed, descriptions.EnemyDescription.MaxSpeed,descriptions.EnemyDescription.AlienSpeed,
                descriptions.EnemyDescription.AlienChance, descriptions.EnemyDescription.AsteroidChance,
                descriptions.EnemyDescription.SpawnRate);
            ShotData = new ShotData(descriptions.ShotDescription.BulletSpeed,descriptions.ShotDescription.LaserSpeed, descriptions.ShotDescription.FireRate,descriptions.ShotDescription.BlastRate,descriptions.ShotDescription.BulletHp,descriptions.ShotDescription.LaserHp,descriptions.ShotDescription.ShotLifeTime,descriptions.ShotDescription.LaserLifeTime);
            ShipData = new ShipData(descriptions.ShipDescription.Speed, descriptions.ShipDescription.Hp);
            SpawnAreas = descriptions.SpawnAreas;
            GameArea = descriptions.GameArea;
            ScoreData = new ScoreData(descriptions.ScoreDescription.TimeMultiplier,
                descriptions.ScoreDescription.KillMultiplier);
        }
    }
}