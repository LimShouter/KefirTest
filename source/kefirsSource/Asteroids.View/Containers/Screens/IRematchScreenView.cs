using System;
using Asteroids.View.ViewManagers.Screens.GameScreenView;

namespace Asteroids.View.Containers.Screens
{
    public interface IRematchScreenView : IScreenView
    {
        IScoreTextView ScoreTextView { get; }
        event Action OnPlay;
    }
}