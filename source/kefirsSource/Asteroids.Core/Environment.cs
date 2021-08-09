using Asteroids.Core.Pull;

namespace Asteroids.Core
{
    public class Environment
    {
        public readonly CollectionContainer CollectionContainer = new CollectionContainer();
        public readonly EnvironmentData EnvironmentData;
        public readonly PullCollection PullCollection = new PullCollection();

        public Environment(DescriptionCollection descriptions, ISaveModel saveModel)
        {
            EnvironmentData = new EnvironmentData(descriptions, saveModel);
        }
    }
}