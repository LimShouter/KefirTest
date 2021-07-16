using System;
using System.Collections.Generic;

namespace Asteroids.Data.Shot
{
    public class ShotFactoryData
    {

        public event Action<ShotType> OnCreate;
        public event Action OnUpdate;
        
        public readonly List<SubShotData> SubShotDatas = new List<SubShotData>();
        public readonly List<SubShotData> DeletedDatas = new List<SubShotData>();

        public void Destroy(SubShotData obj)
        {
            if (!DeletedDatas.Contains(obj))
            {
                DeletedDatas.Add(obj);
            }
        }

        public void Create(ShotType type)
        {
            OnCreate?.Invoke(type);
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}