using System;
using Asteroids.Data.Screens;

namespace Asteroids.Data
{
    public class GameManagerData
    {
        public event Action OnPlay;
        public event Action OnStop;

        public BaseScreenData CurrentScreen;

        public void Play()
        {
            OnPlay?.Invoke();
        }

        public void Stop()
        {
            OnStop?.Invoke();
        }
    }
}