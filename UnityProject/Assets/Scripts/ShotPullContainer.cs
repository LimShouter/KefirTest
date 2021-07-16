using System.Collections.Generic;
using Asteroids.View;
using UnityEngine;

public class ShotPullContainer : BaseCustomSpriteRenderer,IPullContainer<ISubShotView>
{
    [SerializeField] private int startCount;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform root;
    private List<SubShotView> _gameObjects = new List<SubShotView>();
    private Sprite _sprite;
        
    public ISubShotView CreateObject()
    {
        var go = Instantiate(prefab, root);
        var subShotView = go.GetComponent<SubShotView>();
        subShotView.SetSprite(_sprite);
        _gameObjects.Add(subShotView);
        return subShotView;
    }

    public void DestroyObject(ISubShotView component)
    {
        var monobeh = component as SubShotView;
        Destroy(monobeh);
        _gameObjects.Remove(monobeh);
    }

    public int GetStartCount()
    {
        return startCount;
    }

    public override void SetSprite(Sprite sprite)
    {
        _sprite = sprite;
        foreach (var view in _gameObjects)
        {
            view.SetSprite(sprite);
        }
    }


}