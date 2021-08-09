using Asteroids.View;
using Asteroids.View.Containers;
using Asteroids.View.Containers.Screens;
using Asteroids.View.ViewManagers;
using Asteroids.View.ViewManagers.Screens;

namespace Asteroids.Core
{
    public interface IEnvironmentView
    {
        IInputView InputView { get; }
        IShipView ShipView { get; }

        IPullContainerCollection PullContainerCollection { get; }
        IStartScreenView StartScreenView { get;}
        IGameScreenView GameScreenView { get; }
        IRematchScreenView RematchScreenView { get; }
    }
}