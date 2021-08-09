using Asteroids.Core;
using Asteroids.Data.Screens;
using Asteroids.View.Containers.Screens;

namespace Asteroids.Presenters.Screens
{
    public abstract class BaseScreenPresenter<TData, TView> : IPresenter
        where TData : BaseScreenData where TView : IScreenView
    {
        protected readonly TData _data;
        protected readonly Environment _environment;
        protected readonly TView _view;

        protected BaseScreenPresenter(Environment environment, TData data, TView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public virtual void Attach()
        {
            _data.OnShow += Show;
            _data.OnHide += Hide;
        }

        public virtual void Detach()
        {
            _data.OnShow -= Show;
            _data.OnHide -= Hide;
        }

        protected virtual void Hide()
        {
            _view.Dispose();
            _view.Hide();
        }

        protected virtual void Show()
        {
            _view.Init();
            _view.Show();
            _environment.EnvironmentData.GameManagerData.CurrentScreen = _data;
        }
    }
}