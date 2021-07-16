using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters
{
    public class ScoreStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var presenter = new ScorePresenter(environmentData,environmentData.ScoreData);
            presenters.Add(presenter);
        }
    }
}