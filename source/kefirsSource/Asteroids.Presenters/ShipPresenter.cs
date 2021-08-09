using Asteroids.Core;
using Asteroids.Data;
using Asteroids.View;

namespace Asteroids.Presenters
{
    public class ShipPresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly ShipData _data;
        private readonly IShipView _view;

        public ShipPresenter(EnvironmentData environmentData,ShipData data,IShipView view)
        {
            _environmentData = environmentData;
            _data = data;
            _view = view;
        }
        public void Attach()
        {
            _data.Hp = _data.ShipDescription.Hp;
            _environmentData.InputData.OnMove += Move;
            _view.OnDamage += Damage;
        }

        public void Detach()
        {
            _environmentData.InputData.OnMove -= Move;
            _view.OnDamage -= Damage;
        }

        private void Damage()
        {
            --_data.Hp;
            if (_data.Hp <= 0  )
            {
                _environmentData.GameManagerData.Stop();
            }
            _data.Damage();
        }

        private void Move(float x, float y)
        {
            _view.Move(x,y,_data.ShipDescription.Speed,out _data.Position,out _data.Rotation);
        }
    }
}