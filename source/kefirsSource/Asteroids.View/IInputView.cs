using System;

namespace Asteroids.View
{
    public interface IInputView
    {
        event Action<float,float> Move;
        event Action Fire;
        event Action Blast;
    }
}