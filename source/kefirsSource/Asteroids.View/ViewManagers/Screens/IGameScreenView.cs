namespace Asteroids.View.Screens
{
    public interface IGameScreenView : IScreenView
    {
        void SetCurrentScore(int score);
        void SetMaxScore(int maxScore);
        void SetMaxHp(int maxHp);
        void SetCurrentHp(int hp);
        void SetBulletReloadMarker(bool state);
        void SetLaserReloadMarker(bool state);
    }
}