using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Screens;

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
            _environmentData.ScoreData.OnSetCurrentScore += _view.SetScore;
            _view.OnPlay += Play;
        }

        public override void Detach()
        {
            base.Detach();
            _environmentData.ScoreData.OnSetCurrentScore -= _view.SetScore;
            _view.OnPlay -= Play;
        }

        private void Play()
        {
            _environmentData.GameManagerData.Play();
        }
    }
}