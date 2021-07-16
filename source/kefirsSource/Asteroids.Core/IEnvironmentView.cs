using Asteroids.View;
using Asteroids.View.Screens;

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