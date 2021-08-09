using System;
using Asteroids.Description;
using Asteroids.Utilities;

namespace Asteroids.Data
{
    public class ShipData
    {
        public readonly ShipDescription ShipDescription;
        public event Action<int> OnDamage;

        public int Hp;
        public Vector2 Position;
        public float Rotation;

        public ShipData(ShipDescription shipDescription)
        {
            ShipDescription = shipDescription;
        }

        public void Damage()
        {
            OnDamage?.Invoke(Hp);
        }
    }
}