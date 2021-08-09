using System;

namespace Asteroids.Data
{
    public class ReactField<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnNotifyChanged?.Invoke(_value);
            }
        }

        public event Action<T> OnNotifyChanged;
    }
}