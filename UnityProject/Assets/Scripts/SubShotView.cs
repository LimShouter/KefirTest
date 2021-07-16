using System;
using Asteroids.View;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = Asteroids.Utilities.Vector2;


public class SubShotView : MonoBehaviour,ISubShotView
{
    [SerializeField] private Image image;

    public event Action OnDamage;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    Vector2 ISubShotView.Move(float speed)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        return new Vector2(transform.position.x, transform.position.y);
    }

    public void SetPosition(Vector2 position, float rotation)
    {
        transform.position = new Vector3(position.X, position.Y, transform.position.z);
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"Enemy"))
        {
            OnDamage?.Invoke();
        }
    }

    public void SetSprite(Sprite sprite)
    {
           image.sprite = sprite;
    }
}