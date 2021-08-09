using Asteroids.Core;
using Asteroids.Data;
using Asteroids.View.ViewManagers.Screens.GameScreenView;

namespace Asteroids.Presenters.Screens.GameScreen
{
    public class HealthObserver : IObserver
    {
        private readonly IHealthView _healthView;
        private readonly ReactField<int> _hp;
        private readonly int _maxHp;

        public HealthObserver(ReactField<int> hp, int maxHp, IHealthView healthView)
        {
            _hp = hp;
            _maxHp = maxHp;
            _healthView = healthView;
        }

        public void Activate()
        {
            _hp.OnNotifyChanged += _healthView.SetHealth;
            _healthView.SetMaxHealth(_maxHp);
            _healthView.SetHealth(_hp.Value);
        }

        public void Deactivate()
        {
            _hp.OnNotifyChanged -= _healthView.SetHealth;
        }
    }
}