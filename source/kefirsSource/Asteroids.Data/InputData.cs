using System;

namespace Asteroids.Data
{
    public class InputData
    {
        public event Action<float, float> OnMove;
        public event Action OnFire;
        public event Action OnBlast;

        public void Move(float x, float y)
        {
            OnMove?.Invoke(x, y);
        }

        public void Fire()
        {
            OnFire?.Invoke();
        }

        public void Blast()
        {
            OnBlast?.Invoke();
        }
    }
}