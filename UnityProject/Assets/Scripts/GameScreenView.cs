using System.Collections.Generic;
using Asteroids.View.Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenView : BaseCustomSpriteRenderer,IGameScreenView
{
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Toggle bulletMarker;
    [SerializeField] private Toggle laserMarker;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform hpRoot;
    [SerializeField] private GameObject hpPrefab;
    private List<GameObject> hpPrefabs =new List<GameObject>();
    private Sprite _sprite;

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Init()
    {
    }

    public void Dispose()
    {
    }

    public void SetCurrentScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetMaxScore(int maxScore)
    {
        maxScoreText.text = maxScore.ToString();
    }

    public void SetMaxHp(int maxHp)
    {
        slider.maxValue = maxHp;
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

    public void SetCurrentHp(int hp)
    {
        slider.value = hp;
    }

    public void SetBulletReloadMarker(bool state)
    {
        bulletMarker.isOn = state;
    }

    public void SetLaserReloadMarker(bool state)
    {
        laserMarker.isOn = state;
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