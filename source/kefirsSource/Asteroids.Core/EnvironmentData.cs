using System.Collections.Generic;
using Asteroids.Data;
using Asteroids.Data.Enemies;
using Asteroids.Data.Shot;
using Asteroids.Description;
using Asteroids.View.Containers;

namespace Asteroids.Core
{
    public class EnvironmentData
    {
        public readonly EnemyData EnemyData;
        public readonly GameManagerData GameManagerData = new GameManagerData();
        public readonly InputData InputData = new InputData();
        public readonly ICustomRandom Random;
        public readonly ISaveModel SaveModel;
        public readonly ScoreData ScoreData;
        public readonly ScreenData ScreenData = new ScreenData();
        public readonly ShipData ShipData;
        public readonly ShotData ShotData;

        public EnvironmentData(DescriptionCollection descriptions, ISaveModel saveModel)
        {
            SaveModel = saveModel;
            Random = descriptions.CustomRandom;
            EnemyData = new EnemyData(descriptions.EnemyDescription);
            ShotData = new ShotData(descriptions.ShotDescription);
            ShipData = new ShipData(descriptions.ShipDescription);
            
            ScoreData = new ScoreData(descriptions.ScoreDescription);
        }
    }
}