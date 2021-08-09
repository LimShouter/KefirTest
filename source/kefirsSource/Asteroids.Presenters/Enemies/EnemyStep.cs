using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids.Presenters.Enemies
{
    public class EnemyStep : IStep
    {
        public void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView)
        {
            var presenter = new EnemyPresenter(environment, environment.EnvironmentData.EnemyData);
            presenters.Add(presenter);
        }
    }
}