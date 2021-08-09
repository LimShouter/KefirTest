using System;
using Asteroids.Utilities;

namespace Asteroids.View.ViewManagers
{
    public interface ISubShotView : IPullObject
    {
        event Action OnDamage;
        void SetPosition(Vector2 position, float rotation);

        Vector2 Move(float speed);
    }
}