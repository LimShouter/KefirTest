using System;

namespace Asteroids.Data.Updater
{
    public class Updater
    {
        public event Action OnUpdate;

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}