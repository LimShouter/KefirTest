using System;

namespace Asteroids.Data.Screens
{
    public class GameScreenData : BaseScreenData
    {
        public event Action<bool> OnSetLaserReloadMarker;
        public event Action<bool> OnSetBulletReloadMarker;

        public void SetBulletReloadMarker(bool state)
        {
            OnSetBulletReloadMarker?.Invoke(state);
        }

        public void SetLaserReloadMarker(bool state)
        {
            OnSetLaserReloadMarker?.Invoke(state);
        }
    }
}