using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class GameManagerStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var presenter = new GameManagerPresenter(environment, environment.EnvironmentData.GameManagerData,
                environmentView);
            presenters.Add(presenter);
        }
    }
}