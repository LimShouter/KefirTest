
namespace Asteroids.Description
{
    public class GameArea
    {
        public readonly int XMin;
        public readonly int XMax;
        public readonly int YMin;
        public readonly int YMax;

        public GameArea(int xMax, int xMin, int yMin, int yMax)
        {
            YMax = yMax;
            YMin = yMin;
            XMax = xMax;
            XMin = xMin;
        }
    }
}