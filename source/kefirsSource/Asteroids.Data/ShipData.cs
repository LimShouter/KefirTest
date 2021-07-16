using System;
using Asteroids.Utilities;

namespace Asteroids.Data
{
    public class ShipData
    {
        public event Action<int> OnDamage;

        public readonly int MaxHp;
        public int Hp;
        public Vector2 Position;
        public float Rotation;
        public readonly float Speed;

        public ShipData(float speed, int hp)
        {
            Speed = speed;
            MaxHp = hp;
        }

        public void Damage()
        {
            OnDamage?.Invoke(Hp);
        }
    }
}