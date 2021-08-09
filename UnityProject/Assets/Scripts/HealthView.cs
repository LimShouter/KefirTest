using System.Collections.Generic;
using Asteroids.View.ViewManagers.Screens.GameScreenView;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : BaseCustomSpriteRenderer,IHealthView
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Transform hpRoot;
    [SerializeField] private GameObject hpPrefab;

    private List<GameObject> hpPrefabs =new List<GameObject>();
    private Sprite _sprite;

    public void SetMaxHealth(int maxHp)
    {
        hpBar.maxValue = maxHp;
        foreach (var go in hpPrefabs)
        {
            Destroy(go);
        }
        hpPrefabs.Clear();
        for (int i = 0; i < maxHp; i++)
        {
            hpPrefabs.Add(Instantiate(hpPrefab, hpRoot));
        }
        SetSprite(_sprite);
    }

    public void SetHealth(int hp)
    {
        hpBar.value = hp;
    }

    public override void SetSprite(Sprite sprite)
    {
        _sprite = sprite;
        foreach (var prefab in hpPrefabs)
        {
            prefab.GetComponent<Image>().sprite = sprite;
        }
    }
}