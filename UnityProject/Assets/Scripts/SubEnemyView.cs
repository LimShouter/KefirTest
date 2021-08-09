using System;
using Asteroids.View;
using Asteroids.View.ViewManagers;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = Asteroids.Utilities.Vector2;

public class SubEnemyView : MonoBehaviour,ISubEnemyView
{
    [SerializeField] private GameObject imageGo;
    [SerializeField] private Image image;
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetTransform(Vector2 pos, float direction)
    {
        transform.position = new Vector3(pos.X,pos.Y,transform.position.z);
        imageGo.transform.eulerAngles = new Vector3(0, 0, -direction*Mathf.Rad2Deg);
    }

    Vector2 ISubEnemyView.Move(float direction, float speed)
    {
        imageGo.transform.localEulerAngles = new Vector3(0, 0, -1*transform.eulerAngles.z);
        transform.eulerAngles = new Vector3(0, 0, -direction*Mathf.Rad2Deg);
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        return new Vector2(transform.position.x, transform.position.y);
    }
        
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag($"Shot")|| other.gameObject.CompareTag($"Ship"))
        {
            OnKill?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"Shot")|| other.gameObject.CompareTag($"Ship"))
        {
            OnKill?.Invoke();
        }
    }

    public event Action OnKill;
}