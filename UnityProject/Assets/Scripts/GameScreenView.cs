using Asteroids.View.Containers.Screens;
using Asteroids.View.ViewManagers.Screens.GameScreenView;
using DefaultNamespace;
using UnityEngine;

public class GameScreenView : MonoBehaviour,IGameScreenView
{
    [SerializeField]private HealthView healthView;
    [SerializeField]private ReloadMarkerView reloadMarkerView;
    [SerializeField]private ScoreTextView scoreTextView;


    public IHealthView HealthView => healthView;
    public IReloadMarkerView ReloadMarkerView => reloadMarkerView;
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
    }

    public void Dispose()
    {
    }
}