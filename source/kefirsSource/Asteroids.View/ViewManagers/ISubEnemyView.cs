using System;
using Asteroids.Utilities;

namespace Asteroids.View.ViewManagers
{
    public interface ISubEnemyView : IPullObject
    {
        event Action OnKill;

        void SetTransform(Vector2 pos, float direction);
        Vector2 Move(float direction, float speed);
    }
}