using Asteroids.View.ViewManagers.Screens;
using Asteroids.View.ViewManagers.Screens.GameScreenView;

namespace Asteroids.View.Containers.Screens
{
    public interface IGameScreenView : IScreenView
    {
        IHealthView HealthView { get; }
        IReloadMarkerView ReloadMarkerView { get; }
        IScoreTextView ScoreTextView { get; }
    }
}