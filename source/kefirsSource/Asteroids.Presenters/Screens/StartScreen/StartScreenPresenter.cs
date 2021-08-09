using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;
using Asteroids.View.ViewManagers.Screens;

namespace Asteroids.Presenters.Screens
{
    public class StartScreenPresenter : BaseScreenPresenter<StartScreenData,IStartScreenView>
    {
        public StartScreenPresenter(EnvironmentData environmentData, StartScreenData data, IStartScreenView view) : base(environmentData, data, view)
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
            _environmentData.GameManagerData.Play();
        }
    }
}