using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class InputStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var presenter = new InputPresenter(environmentData, environmentData.InputData, environmentView.InputView);
            presenters.Add(presenter);
        }
    }
}