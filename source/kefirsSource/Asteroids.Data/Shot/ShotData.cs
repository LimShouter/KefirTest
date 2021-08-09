using System;
using Asteroids.Description;

namespace Asteroids.Data.Shot
{
    public class ShotData
    {
        public event Action OnUpdate;
        public readonly ReactField<bool> BulletReload = new ReactField<bool>();
        public readonly ReactField<bool> LaserReload = new ReactField<bool>();
        public readonly ShotDescription ShotDescription;
        public readonly ShotFactoryData ShotFactoryData = new ShotFactoryData();

        public ShotData(ShotDescription shotDescription)
        {
            ShotDescription = shotDescription;
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}