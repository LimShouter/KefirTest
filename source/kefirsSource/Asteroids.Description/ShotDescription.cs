using System;

namespace Asteroids.Description
{
    [Serializable]
    public class ShotDescription
    {
        public float BulletSpeed;
        public float LaserSpeed;
        public float FireRate;
        public float BlastRate;
        public float ShotLifeTime;
        public float LaserLifeTime;
        public int LaserHp;
        public int BulletHp;
    }
}