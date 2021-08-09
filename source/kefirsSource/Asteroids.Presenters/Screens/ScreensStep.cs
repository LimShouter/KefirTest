using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Presenters.Screens.GameScreen;

namespace Asteroids.Presenters.Screens
{
    public class ScreensStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var startScreenPresenter = new StartScreenPresenter(environmentData,environmentData.ScreenData.StartScreenData,environmentView.StartScreenView);
            var gameScreenPresenter = new GameScreenPresenter(environmentData,environmentData.ScreenData.GameScreenData,environmentView.GameScreenView);
            var rematchScreenPresenter = new RematchScreenPresenter(environmentData,environmentData.ScreenData.RematchScreenData,environmentView.RematchScreenView);
            presenters.Add(startScreenPresenter);
            presenters.Add(gameScreenPresenter);
            presenters.Add(rematchScreenPresenter);
        }
    }
}