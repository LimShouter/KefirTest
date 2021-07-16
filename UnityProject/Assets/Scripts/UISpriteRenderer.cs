using UnityEngine;
using UnityEngine.UI;

public class UISpriteRenderer : BaseCustomSpriteRenderer
{
    [SerializeField] public string nameInAtlas;
    [SerializeField] private Image image;
    public override void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}