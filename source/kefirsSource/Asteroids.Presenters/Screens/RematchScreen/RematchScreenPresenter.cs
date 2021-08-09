using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;

namespace Asteroids.Presenters.Screens.RematchScreen
{
    public class RematchScreenPresenter : BaseScreenPresenter<RematchScreenData, IRematchScreenView>
    {
        public RematchScreenPresenter(Environment environment, RematchScreenData data, IRematchScreenView view) : base(
            environment, data, view)
        {
        }

        public override void Attach()
        {
            base.Attach();
            _environment.EnvironmentData.ScoreData.CurrentScore.OnNotifyChanged += _view.ScoreTextView.SetScore;
            _view.OnPlay += Play;
        }

        public override void Detach()
        {
            base.Detach();
            _environment.EnvironmentData.ScoreData.CurrentScore.OnNotifyChanged -= _view.ScoreTextView.SetScore;
            _view.OnPlay -= Play;
        }

        private void Play()
        {
            _environment.EnvironmentData.GameManagerData.Play();
        }
    }
}