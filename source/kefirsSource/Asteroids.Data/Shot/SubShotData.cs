using System;
using Asteroids.Utilities;

namespace Asteroids.Data.Shot
{
    public class SubShotData
    {
        public readonly float LifeTime;
        public readonly float Rotation;
        public readonly ShotType Type;
        public int Hp;
        public Vector2 Position;

        public SubShotData(Vector2 position, float rotation, int hp, float lifeTime, ShotType type)
        {
            Position = position;
            Rotation = rotation;
            Hp = hp;
            Type = type;
            LifeTime = lifeTime;
        }

        public event Action OnUpdate;

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}