using System.Collections.Generic;

namespace Asteroids.Core
{
    public interface ISaveModel
    {
        void Set<T>(string key, T value);

        T Get<T>(string key);

        List<T> GetList<T>(string key);
    }
}