using System.Collections.Generic;
using Asteroids.View;
using Asteroids.View.Containers;
using Asteroids.View.ViewManagers;
using UnityEngine;

public class EnemyPullContainer : BaseCustomSpriteRenderer, IPullContainer<ISubEnemyView>
{
    [SerializeField] private string AddressableName;
    [SerializeField] private int startCount;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform root;
    private List<SubEnemyView> _gameObjects = new List<SubEnemyView>();
    private Sprite _sprite;
        
    public ISubEnemyView CreateObject()
    {
        var go = Instantiate(prefab, root);
        var subEnemyView = go.GetComponent<SubEnemyView>();
        subEnemyView.SetSprite(_sprite);
        _gameObjects.Add(subEnemyView);
        return subEnemyView;
    }

    public void DestroyObject(ISubEnemyView component)
    {
        var monobeh = component as SubEnemyView;
        Destroy(monobeh);
        _gameObjects.Remove(monobeh);
    }

    public int GetStartCount()
    {
        return startCount;
    }

    public string GetAddressableName()
    {
        return AddressableName;
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