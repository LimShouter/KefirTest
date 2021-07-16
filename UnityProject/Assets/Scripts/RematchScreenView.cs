using System;
using Asteroids.View.Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RematchScreenView : MonoBehaviour,IRematchScreenView
{
    public event Action OnPlay;

    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

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