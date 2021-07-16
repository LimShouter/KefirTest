using System;
using System.Collections.Generic;
using Asteroids.Data.Shot;

namespace Asteroids.Data.Enemies
{
    public class EnemyFactoryData
    {
        public event Action<EnemyType> OnGenerate;
        public event Action OnUpdate;
        public event Action OnKill;

        public readonly List<SubEnemyData> SubEnemyDatas = new List<SubEnemyData>();
        public readonly List<SubEnemyData> DeletedDatas = new List<SubEnemyData>();
        
        public void Generate(EnemyType type)
        {
            OnGenerate?.Invoke(type);
        }

        public void Destroy(SubEnemyData obj)
        {
            if (!DeletedDatas.Contains(obj))
            {            
                DeletedDatas.Add(obj);
            }
        }

        public void Kill()
        {
            OnKill?.Invoke();
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}