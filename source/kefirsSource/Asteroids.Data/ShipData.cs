using Asteroids.Description;
using Asteroids.Utilities;

namespace Asteroids.Data
{
    public class ShipData
    {
        public readonly ReactField<int> Hp = new ReactField<int>();
        public readonly ShipDescription ShipDescription;
        public Vector2 Position;
        public float Rotation;

        public ShipData(ShipDescription shipDescription)
        {
            ShipDescription = shipDescription;
        }
    }
}