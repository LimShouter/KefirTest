using System.Collections.Generic;
using Asteroids.Description;

namespace Asteroids.Core
{
    public class GameStaticFields
    {
        public readonly GameArea GameArea;
        public readonly List<GameArea> SpawnAreas;

        public GameStaticFields(DescriptionCollection descriptions)
        {
            SpawnAreas = descriptions.SpawnAreas;
            GameArea = descriptions.GameArea;
        }
    }
}