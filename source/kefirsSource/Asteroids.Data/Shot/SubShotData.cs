using System;
using Asteroids.Utilities;

namespace Asteroids.Data.Shot
{
    public class SubShotData
    {
        public event Action OnUpdate;
        public readonly ShotType Type;
        public int Hp;
        public readonly float LifeTime;
        public Vector2 Position;
        public readonly float Rotation;

        public SubShotData(Vector2 position, float rotation, int hp, float lifeTime, ShotType type)
        {
            Position = position;
            Rotation = rotation;
            Hp = hp;
            this.Type = type;
            LifeTime = lifeTime;
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}