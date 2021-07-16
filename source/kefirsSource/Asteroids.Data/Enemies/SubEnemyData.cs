using System;
using Asteroids.Utilities;

namespace Asteroids.Data.Enemies
{
    public class SubEnemyData
    {
        public event Action OnUpdate;
        public readonly EnemyType Type;
        public readonly bool CanSpawnOther;
        public Vector2 Position;
        public float Direction;
        public readonly float Speed;

        public SubEnemyData(EnemyType type, bool canSpawnOther, float speed, Vector2 position, float direction)
        {
            CanSpawnOther = canSpawnOther;
            Type = type;
            Position = position;
            Direction = direction;
            Speed = speed;
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}