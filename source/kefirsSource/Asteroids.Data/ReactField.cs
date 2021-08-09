using System;

namespace Asteroids.Data
{
    public class ReactField<T>
    {
        public event Action<T> OnNotifyChanged;
        private T _value;
        public T Value { get => _value;
            set
            {
                _value = value;
                OnNotifyChanged?.Invoke(_value);
            } 
        }
    }
}