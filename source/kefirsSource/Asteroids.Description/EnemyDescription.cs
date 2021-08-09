using System;

namespace Asteroids.Description
{
    [Serializable]
    public class EnemyDescription
    {
        public int AlienChance;
        public float AlienSpeed;
        public int AsteroidChance;
        public float MaxSpeed;
        public float MinSpeed;

        public float SpawnRate;
    }
}