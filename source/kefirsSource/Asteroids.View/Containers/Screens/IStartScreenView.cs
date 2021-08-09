using System;

namespace Asteroids.View.Containers.Screens
{
    public interface IStartScreenView : IScreenView
    {
        event Action OnPlay;
    }
}