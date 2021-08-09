using System;

namespace Asteroids.View.Screens
{
    public interface IRematchScreenView : IScreenView
    {
        event Action OnPlay;
        void SetScore(int score);
    }
}