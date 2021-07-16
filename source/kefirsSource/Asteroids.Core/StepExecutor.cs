using System.Collections.Generic;

namespace Asteroids.Core
{
    public class StepExecutor : IStep
    {
        private List<IStep> _steps = new List<IStep>();
        
        public void Execute(List<IPresenter> presenters, EnvironmentData environmentData, IEnvironmentView environmentView)
        {
            foreach (var step in _steps)
            {
                step.Execute(presenters,environmentData,environmentView);
            }    
        }

        public void Add(IStep step)
        {
            _steps.Add(step);
        }

        public void Clear()
        {
            _steps.Clear();
        }
    }
}