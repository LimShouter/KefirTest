using Asteroids.Core;
using Asteroids.View;
using Asteroids.View.Screens;
using UnityEngine;

public class EnvironmentView : MonoBehaviour,IEnvironmentView
{
    [SerializeField]private InputView _inputView;
    [SerializeField]private ShipView _shipView;
    [SerializeField]private PullContainerCollection _pullContainerCollection;
    [SerializeField]private StartScreenView _startScreenView;
    [SerializeField]private GameScreenView _gameScreenView;
    [SerializeField]private RematchScreenView _rematchScreenView;

    public IInputView InputView => _inputView;
    public IShipView ShipView => _shipView;
    public IPullContainerCollection PullContainerCollection => _pullContainerCollection;
    public IStartScreenView StartScreenView => _startScreenView;
    public IGameScreenView GameScreenView => _gameScreenView;
    public IRematchScreenView RematchScreenView => _rematchScreenView;
}