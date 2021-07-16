using Asteroids.Data.Screens;

namespace Asteroids.Core
{
    public class ScreenData
    {
        public readonly StartScreenData StartScreenData = new StartScreenData();
        public readonly GameScreenData GameScreenData = new GameScreenData();
        public readonly RematchScreenData RematchScreenData = new RematchScreenData();
    }
}