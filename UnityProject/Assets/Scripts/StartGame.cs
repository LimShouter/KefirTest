using Asteroids;
using UnityEngine;

public class StartGame : MonoBehaviour
{

     [SerializeField] private DescriptionSo descriptionSo;
     [SerializeField] private EnvironmentView environmentView;
     private GameController _gameController;
     private SaveModel _saveModel = new SaveModel();
     private void Awake()
     {
         _gameController = new GameController(descriptionSo.GetDescription(),_saveModel,environmentView);
         _gameController.Awake();
     }
     void Start()
    {
        _gameController.Start();
    }
    void Update()
    {
        _gameController.Update(Time.deltaTime);
    }
}
