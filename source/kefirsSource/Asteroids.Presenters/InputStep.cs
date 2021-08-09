using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class InputStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var presenter = new InputPresenter(environment, environment.EnvironmentData.InputData,
                environmentView.InputView);
            presenters.Add(presenter);
        }
    }
}