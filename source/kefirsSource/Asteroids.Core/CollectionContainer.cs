using Asteroids.Core.Time;
using Asteroids.Data.Updater;

namespace Asteroids.Core
{
    public class CollectionContainer
    {
        public readonly TimerCollection TimerCollection = new TimerCollection();
        public readonly UpdaterCollection UpdaterCollection = new UpdaterCollection();
    }
}