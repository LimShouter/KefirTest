using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class GameManagerStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var presenter = new GameManagerPresenter(environmentData, environmentData.GameManagerData,environmentView);
            presenters.Add(presenter);
        }
    }
}