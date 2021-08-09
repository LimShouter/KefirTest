using System;

namespace Asteroids.Core.Time
{
    public class Timer : ITimer
    {
        private readonly bool _isLoop;
        private bool _isComplete;

        private float _timer;

        public Timer(float timer, bool isLoop)
        {
            _timer = timer;
            _isLoop = isLoop;
        }

        private float Time { get; set; }

        public void Update(float deltaTime)
        {
            Time += deltaTime;
            if (Time > _timer && !_isComplete)
            {
                OnNotify?.Invoke();
                if (_isLoop)
                    Time -= _timer;
                else
                    _isComplete = true;
            }
        }

        public event Action OnNotify;

        public void ChangeTime(float time)
        {
            _timer = time;
        }

        public void Reset()
        {
            Time = 0;
        }
    }
}