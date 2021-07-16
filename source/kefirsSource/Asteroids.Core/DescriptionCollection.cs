using System.Collections.Generic;
using Asteroids.Description;
using Asteroids.View;

namespace Asteroids.Core
{
    public class DescriptionCollection
    {
        public ICustomRandom CustomRandom;
        public readonly ShipDescription ShipDescription;
        public ShotDescription ShotDescription;
        public EnemyDescription EnemyDescription;
        public ScoreDescription ScoreDescription;
        public readonly List<GameArea> SpawnAreas;
        public readonly GameArea GameArea;

        public DescriptionCollection(ShipDescription shipDescription, List<GameArea> spawnAreas, GameArea gameArea, ShotDescription shotDescription, EnemyDescription enemyDescription, ScoreDescription scoreDescription, ICustomRandom customRandom)
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