using System;

namespace Asteroids.View.ViewManagers
{
    public interface IInputView
    {
        event Action<float, float> Move;
        event Action Fire;
        event Action Blast;
    }
}