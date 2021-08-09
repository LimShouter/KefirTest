using System;
using Asteroids.Utilities;

namespace Asteroids.View.ViewManagers
{
    public interface IShipView
    {
        event Action OnDamage;
        void Move(float x, float y, float speed, out Vector2 position, out float rotation);
    }
}