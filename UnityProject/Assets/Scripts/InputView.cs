using System;
using Asteroids.View;
using UnityEngine;

public class InputView : MonoBehaviour,IInputView
{
    public event Action<float, float> Move;
    public event Action Fire;
    public event Action Blast;
        
    [SerializeField] private GameObject observedObject;
    private void Update()
    {
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,observedObject.transform.position.z-Camera.main.transform.position.z));
        var position = observedObject.transform.position;
        var normalizedDifference = (mouseWorldPosition-position);
        Move?.Invoke(normalizedDifference.x,normalizedDifference.y);
        if (Input.GetMouseButton(0))
        {
            Fire?.Invoke();
        }

        if (Input.GetMouseButton(1))
        {
            Blast?.Invoke();
        }
    }
}