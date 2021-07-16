using System;
using UnityEngine;
using UnityEngine.UI;

public class AlfaChanger : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private int AlfaSpeed;
    private void OnEnable()
    {
        _image.color = new Color(255,255,255,255);
    }

    private void Update()
    {
        _image.color = new Color(255, 255, 255, _image.color.a + AlfaSpeed);
    }
}
