namespace Asteroids.View
{
    public interface IPullContainer<TComponent> where TComponent : IPullObject
    {
        TComponent CreateObject();
        void DestroyObject(TComponent component);
        int GetStartCount();
    }
}