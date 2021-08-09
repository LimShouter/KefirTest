using Asteroids.Core;
using Asteroids.Data;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters
{
    public class InputPresenter : IPresenter
    {
        private readonly InputData _data;
        private readonly Environment _environment;
        private readonly IInputView _view;

        public InputPresenter(Environment environment, InputData data, IInputView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.Move += _data.Move;
            _view.Fire += _data.Fire;
            _view.Blast += _data.Blast;
        }

        public void Detach()
        {
            _view.Move -= _data.Move;
            _view.Fire -= _data.Fire;
            _view.Blast -= _data.Blast;
        }
    }
}