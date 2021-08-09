using System;

namespace Asteroids.View.Screens
{
    public interface IStartScreenView : IScreenView
    {
        event Action OnPlay;
    }
}