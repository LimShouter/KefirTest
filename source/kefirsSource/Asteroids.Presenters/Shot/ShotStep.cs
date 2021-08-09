using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters.Shot
{
    public class ShotStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var presenter = new ShotPresenter(environment, environment.EnvironmentData.ShotData);
            presenters.Add(presenter);
        }
    }
}