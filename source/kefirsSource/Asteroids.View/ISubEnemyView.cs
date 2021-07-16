using System;
using Asteroids.Utilities;

namespace Asteroids.View
{
    public interface ISubEnemyView : IPullObject
    {
        event Action OnKill;

        void SetTransform(Vector2 pos,float direction);
        Vector2 Move(float direction, float speed);
    }
}