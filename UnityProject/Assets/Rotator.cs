using UnityEngine;
public class Rotator : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float X;
    [SerializeField] private float Y;
    [SerializeField] private float Z;
    void Update()
    {
        transform.Rotate(X*Speed,Y*Speed,Z*Speed);
    }
}
