using Asteroids.Core;
using Asteroids.Data;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters
{
    public class ShipPresenter : IPresenter
    {
        private readonly ShipData _data;
        private readonly Environment _environment;
        private readonly IShipView _view;

        public ShipPresenter(Environment environment, ShipData data, IShipView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _data.Hp.Value = _data.ShipDescription.Hp;
            _environment.EnvironmentData.InputData.OnMove += Move;
            _view.OnDamage += Damage;
        }

        public void Detach()
        {
            _environment.EnvironmentData.InputData.OnMove -= Move;
            _view.OnDamage -= Damage;
        }

        private void Damage()
        {
            --_data.Hp.Value;
            if (_data.Hp.Value <= 0) _environment.EnvironmentData.GameManagerData.Stop();
        }

        private void Move(float x, float y)
        {
            _view.Move(x, y, _data.ShipDescription.Speed, out _data.Position, out _data.Rotation);
        }
    }
}