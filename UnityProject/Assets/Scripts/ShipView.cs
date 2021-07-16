using System;
using Asteroids.View;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = Asteroids.Utilities.Vector2;

public class ShipView : BaseCustomSpriteRenderer,IShipView
{
    public event Action OnDamage;
    [SerializeField] private Image _image;

    public void Move(float x, float y, float speed, out Vector2 position, out float rotation)
    {
        var rotationZ = -Mathf.Atan2(x, y)*Mathf.Rad2Deg;
        if (Mathf.Abs(x) > 0.2f||Mathf.Abs(y) > 0.2f)
        {
            gameObject.transform.eulerAngles = new Vector3(0,0,rotationZ);
            gameObject.transform.Translate(new Vector3(0,1,0)*speed*Time.deltaTime);
        }
        position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
        rotation = rotationZ;
    }

    public override void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnDamage?.Invoke();
        }
    }
}