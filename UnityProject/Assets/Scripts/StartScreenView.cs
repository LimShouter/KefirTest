using System;
using Asteroids.View.Containers.Screens;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenView : MonoBehaviour, IStartScreenView

{
    public event Action OnPlay;
        
    [SerializeField] private Button playButton;


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
        playButton.onClick.AddListener(Play);
    }

    public void Dispose()
    {
        playButton.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        OnPlay?.Invoke();
    }
}