using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class ShipStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var presenter = new ShipPresenter(environmentData, environmentData.ShipData, environmentView.ShipView);
            presenters.Add(presenter);
        }
    }
}