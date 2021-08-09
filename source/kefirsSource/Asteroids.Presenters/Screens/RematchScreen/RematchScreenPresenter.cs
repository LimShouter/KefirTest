using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;
using Asteroids.View.ViewManagers.Screens;

namespace Asteroids.Presenters.Screens
{
    public class RematchScreenPresenter : BaseScreenPresenter<RematchScreenData,IRematchScreenView>
    {
        public RematchScreenPresenter(EnvironmentData environmentData, RematchScreenData data, IRematchScreenView view) : base(environmentData, data, view)
        {
        }

        public override void Attach()
        {
            base.Attach();
            _view.ScoreTextView.SetScore(_environmentData.ScoreData.CurrentScore.Value);
            _view.OnPlay += Play;
        }

        public override void Detach()
        {
            base.Detach();
            _view.OnPlay -= Play;
        }

        private void Play()
        {
            _environmentData.GameManagerData.Play();
        }
    }
}