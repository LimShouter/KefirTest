using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Presenters;
using Asteroids.Presenters.Screens;

namespace Asteroids
{
    public class GameController
    {
        private readonly EnvironmentData _environmentData;
        private readonly IEnvironmentView _environmentView;
        private readonly StepExecutor _stepExecutor = new StepExecutor();
        private readonly List<IPresenter> _globalPresenters = new List<IPresenter>();

        public GameController(DescriptionCollection descriptionCollection,ISaveModel saveModel, IEnvironmentView environmentView)
        {
            _environmentView = environmentView;
            _environmentData = new EnvironmentData(descriptionCollection,saveModel);
        }

        public void Awake()
        {
            _stepExecutor.Add(new GameManagerStep());
            _stepExecutor.Add(new ScreensStep());
        }
        
        public void Start()
        {
            _environmentData.AlienPull.Init(_environmentView.PullContainerCollection.AlienPullContainer);
            _environmentData.AsteroidPull.Init(_environmentView.PullContainerCollection.AsteroidPullContainer);
            _environmentData.AsteroidPiecePull.Init(_environmentView.PullContainerCollection.AsteroidPiecePullContainer);
            _environmentData.ShotsPull.Init(_environmentView.PullContainerCollection.ShotPullContainer);
            _environmentData.LaserPull.Init(_environmentView.PullContainerCollection.LaserPullContainer);
            _stepExecutor.Execute(_globalPresenters,_environmentData,_environmentView);
            foreach (var presenter in _globalPresenters)
            {
                presenter.Attach();
            }
            _environmentData.ScreenData.StartScreenData.Show();
        }

        public void Update(float deltaTime)
        {
            _environmentData.TimerCollection.Update(deltaTime);
            _environmentData.UpdaterCollection.Update();
        }
    }
}