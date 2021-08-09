using Asteroids.View.ViewManagers.Screens.GameScreenView;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ReloadMarkerView : MonoBehaviour,IReloadMarkerView
    {
        [SerializeField] private Toggle laserMarker;
        [SerializeField] private Toggle bulletMarker;

        public void SetLaserMarker(bool state)
        {
            laserMarker.isOn = state;
        }

        public void SetBulletMarker(bool state)
        {
            bulletMarker.isOn = state;
        }
    }
}