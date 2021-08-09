using System.Collections.Generic;

namespace Asteroids.Data.Updater
{
    public class UpdaterCollection
    {
        private readonly List<Updater> _updaters = new List<Updater>();

        public void Add(Updater updater)
        {
            _updaters.Add(updater);
        }

        public void Remove(Updater updater)
        {
            _updaters.Remove(updater);
        }

        public void Clear()
        {
            _updaters.Clear();
        }

        public void Update()
        {
            foreach (var updater in _updaters) updater.Update();
        }
    }
}