using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Presenters;
using Asteroids.Presenters.Screens;

namespace Asteroids
{
    public class GameController
    {
        private readonly Environment _environment;
        private readonly IEnvironmentView _environmentView;
        private readonly List<IPresenter> _globalPresenters = new List<IPresenter>();
        private readonly StepExecutor _stepExecutor = new StepExecutor();

        public GameController(DescriptionCollection descriptionCollection, ISaveModel saveModel,
            IEnvironmentView environmentView)
        {
            _environmentView = environmentView;
            _environment = new Environment(descriptionCollection, saveModel);
        }

        public void Awake()
        {
            _stepExecutor.Add(new GameManagerStep());
            _stepExecutor.Add(new ScreensStep());
        }

        public void Start()
        {
            _environment.PullCollection.AlienPull.Init(_environmentView.PullContainerCollection.AlienPullContainer);
            _environment.PullCollection.AsteroidPull.Init(
                _environmentView.PullContainerCollection.AsteroidPullContainer);
            _environment.PullCollection.AsteroidPiecePull.Init(_environmentView.PullContainerCollection
                .AsteroidPiecePullContainer);
            _environment.PullCollection.ShotsPull.Init(_environmentView.PullContainerCollection.ShotPullContainer);
            _environment.PullCollection.LaserPull.Init(_environmentView.PullContainerCollection.LaserPullContainer);
            _stepExecutor.Execute(_globalPresenters, _environment, _environmentView);
            foreach (var presenter in _globalPresenters) presenter.Attach();
            _environment.EnvironmentData.ScreenData.StartScreenData.Show();
        }

        public void Update(float deltaTime)
        {
            _environment.CollectionContainer.TimerCollection.Update(deltaTime);
            _environment.CollectionContainer.UpdaterCollection.Update();
        }
    }
}