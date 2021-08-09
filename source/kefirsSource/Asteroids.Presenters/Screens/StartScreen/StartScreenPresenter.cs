using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;

namespace Asteroids.Presenters.Screens.StartScreen
{
    public class StartScreenPresenter : BaseScreenPresenter<StartScreenData, IStartScreenView>
    {
        public StartScreenPresenter(Environment environment, StartScreenData data, IStartScreenView view) : base(
            environment, data, view)
        {
        }

        public override void Attach()
        {
            base.Attach();
            _view.OnPlay += Play;
        }

        public override void Detach()
        {
            base.Detach();
            _view.OnPlay -= Play;
        }

        private void Play()
        {
            _environment.EnvironmentData.GameManagerData.Play();
        }
    }
}