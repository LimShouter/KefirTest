using System.Collections.Generic;
using Asteroids.Description;
using Asteroids.View.Containers;

namespace Asteroids.Core
{
    public class DescriptionCollection
    {
        public readonly GameArea GameArea;
        public readonly ShipDescription ShipDescription;
        public readonly List<GameArea> SpawnAreas;
        public ICustomRandom CustomRandom;
        public EnemyDescription EnemyDescription;
        public ScoreDescription ScoreDescription;
        public ShotDescription ShotDescription;

        public DescriptionCollection(ShipDescription shipDescription, List<GameArea> spawnAreas, GameArea gameArea,
            ShotDescription shotDescription, EnemyDescription enemyDescription, ScoreDescription scoreDescription,
            ICustomRandom customRandom)
        {
            ShipDescription = shipDescription;
            SpawnAreas = spawnAreas;
            GameArea = gameArea;
            ShotDescription = shotDescription;
            EnemyDescription = enemyDescription;
            ScoreDescription = scoreDescription;
            CustomRandom = customRandom;
        }
    }
}