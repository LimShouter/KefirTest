using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters.Enemies
{
    public class EnemyStep : IStep
    {
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            var presenter = new EnemyPresenter(environmentData,environmentData.EnemyData);
            presenters.Add(presenter);
        }
    }
}