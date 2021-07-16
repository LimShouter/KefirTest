using System;

namespace Asteroids.Description
{
    [Serializable]
    public class EnemyDescription
    {
        public float MinSpeed;
        public float MaxSpeed;
        public float AlienSpeed;

        public int AlienChance;
        public int AsteroidChance;

        public float SpawnRate;
    }
}