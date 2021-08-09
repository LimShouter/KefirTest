namespace Asteroids.Description
{
    public class GameArea
    {
        public readonly int XMax;
        public readonly int XMin;
        public readonly int YMax;
        public readonly int YMin;

        public GameArea(int xMax, int xMin, int yMin, int yMax)
        {
            YMax = yMax;
            YMin = yMin;
            XMax = xMax;
            XMin = xMin;
        }
    }
}