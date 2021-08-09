using Asteroids.Core.Pull;

namespace Asteroids.Core
{
    public class Environment
    {
        public readonly CollectionContainer CollectionContainer = new CollectionContainer();
        public readonly PullCollection PullCollection = new PullCollection();
        public readonly EnvironmentData EnvironmentData;
        public readonly GameStaticFields GameStaticFields;

        public Environment(DescriptionCollection descriptions, ISaveModel saveModel)
        {
            EnvironmentData = new EnvironmentData(descriptions, saveModel);
            GameStaticFields = new GameStaticFields(descriptions);
        }
    }
}