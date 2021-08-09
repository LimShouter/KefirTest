using System;
using Asteroids.Utilities;

namespace Asteroids.Data.Enemies
{
    public class SubEnemyData
    {
        public readonly bool CanSpawnOther;
        public readonly float Speed;
        public readonly EnemyType Type;
        public float Direction;
        public Vector2 Position;

        public SubEnemyData(EnemyType type, bool canSpawnOther, float speed, Vector2 position, float direction)
        {
            CanSpawnOther = canSpawnOther;
            Type = type;
            Position = position;
            Direction = direction;
            Speed = speed;
        }

        public event Action OnUpdate;

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}