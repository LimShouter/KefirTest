using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.U2D;
using UnityEngine.UI;

public class VisualManager : MonoBehaviour
{
    [SerializeField] private List<GameStyleDescriptionSo> _gameStyleDescriptions;
    private ContentManager contentManager = new ContentManager();
    [SerializeField] private Button changeVisualButton;
    [SerializeField] private List<BaseCustomSpriteRenderer> renderers;
    [SerializeField] private List<UISpriteRenderer> uiRenderers;
    [SerializeField] private List<MaterialRenderer> materialRenderers;
    private int _currentVisualLabel;
    private ContentLoader<SpriteAtlas> _spriteLoader;
    private ContentLoader<SpriteAtlas> _uiSpriteLoader;
    private ContentLoader<Material> _materialLoader;

    private void Awake()
    {
        contentManager.Awake();
    }

    private void Start()
    {
        changeVisualButton.onClick.AddListener(ChangeVisual);
        ChangeVisual();
    }

    private  void ChangeVisual()
    {
        _currentVisualLabel = (_currentVisualLabel+1)%_gameStyleDescriptions.Count;
        if (_spriteLoader != null)
        {
            contentManager.GroupUnload(ContentGroups.Game);
            _spriteLoader = null;
        }

        _spriteLoader = contentManager.Create<SpriteAtlas>(ContentGroups.Game,_gameStyleDescriptions[_currentVisualLabel].Description.AtlasKey);
        _spriteLoader.Load();
        _spriteLoader.Loaded += OnSpriteContentLoad;

        if (_materialLoader != null)
        {
            _materialLoader = null;
        }
            
        _materialLoader = contentManager.Create<Material>(ContentGroups.Game,_gameStyleDescriptions[_currentVisualLabel].Description.TrailKey);
        _materialLoader.Load();
        _materialLoader.Loaded += OnMaterialContentLoad;

        if (_uiSpriteLoader != null)
        {
            contentManager.GroupUnload(ContentGroups.UI);
            _uiSpriteLoader = null;
        }

        _uiSpriteLoader = contentManager.Create<SpriteAtlas>(ContentGroups.UI,_gameStyleDescriptions[_currentVisualLabel].Description.UIAtlasKey);
        _uiSpriteLoader.Load();
        _uiSpriteLoader.Loaded += OnUIContentLoad;
    }

    private void OnUIContentLoad()
    {
        _uiSpriteLoader.Loaded -= OnUIContentLoad;
        foreach (var uiSpriteRenderer in uiRenderers)
        {
            uiSpriteRenderer.SetSprite( _uiSpriteLoader.Handler.Result.GetSprite(uiSpriteRenderer.nameInAtlas));
        }
    }

    private void OnMaterialContentLoad()
    {
        _materialLoader.Loaded -= OnMaterialContentLoad;
        materialRenderers[0].SetMaterial(_materialLoader.Handler.Result);
    }

    private void OnSpriteContentLoad()
    {
        _spriteLoader.Loaded -= OnSpriteContentLoad;
        renderers[0].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.AsteroidKey));
        renderers[1].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.AsteroidPieceKey));
        renderers[2].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.AlienKey));
        renderers[3].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.Ship));
        renderers[4].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.Bullet));
        renderers[5].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.Laser));
        renderers[6].SetSprite(_spriteLoader.Handler.Result.GetSprite(_gameStyleDescriptions[_currentVisualLabel].Description.Ship));
    }
}