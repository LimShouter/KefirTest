using System.Collections.Generic;

namespace Asteroids.Core
{
    public interface IStep
    {
        void Execute(List<IPresenter> presenters, Environment environment, IEnvironmentView environmentView);
    }
}