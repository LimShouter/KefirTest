using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class ScoreStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var presenter = new ScorePresenter(environment, environment.EnvironmentData.ScoreData);
            presenters.Add(presenter);
        }
    }
}