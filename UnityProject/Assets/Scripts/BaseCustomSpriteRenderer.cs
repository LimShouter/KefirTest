using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCustomSpriteRenderer : MonoBehaviour,ICustomRenderer
{
    public abstract void SetSprite(Sprite sprite);
}