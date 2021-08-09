using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Presenters.Screens.GameScreen;
using Asteroids.Presenters.Screens.RematchScreen;
using Asteroids.Presenters.Screens.StartScreen;

namespace Asteroids.Presenters.Screens
{
    public class ScreensStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var startScreenPresenter = new StartScreenPresenter(environment,
                environment.EnvironmentData.ScreenData.StartScreenData, environmentView.StartScreenView);
            var gameScreenPresenter = new GameScreenPresenter(environment,
                environment.EnvironmentData.ScreenData.GameScreenData, environmentView.GameScreenView);
            var rematchScreenPresenter = new RematchScreenPresenter(environment,
                environment.EnvironmentData.ScreenData.RematchScreenData, environmentView.RematchScreenView);
            presenters.Add(startScreenPresenter);
            presenters.Add(gameScreenPresenter);
            presenters.Add(rematchScreenPresenter);
        }
    }
}