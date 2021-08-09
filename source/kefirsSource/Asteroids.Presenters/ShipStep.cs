using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class ShipStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var presenter = new ShipPresenter(environment, environment.EnvironmentData.ShipData,
                environmentView.ShipView);
            presenters.Add(presenter);
        }
    }
}