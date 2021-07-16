using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters.Shot
{
    public class ShotStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var presenter = new ShotPresenter(environmentData,environmentData.ShotData);
            presenters.Add(presenter);
        }
    }
}