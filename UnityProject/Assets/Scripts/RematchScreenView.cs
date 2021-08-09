using System;
using Asteroids.View.Containers.Screens;
using Asteroids.View.ViewManagers.Screens.GameScreenView;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RematchScreenView : MonoBehaviour,IRematchScreenView
{
    public event Action OnPlay;

    [SerializeField] private Button playButton;
    [SerializeField] private ScoreTextView scoreTextView;
    public IScoreTextView ScoreTextView => scoreTextView;


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