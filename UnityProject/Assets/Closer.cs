using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Closer : MonoBehaviour
{
    [SerializeField] private Button button;
    void Start()
    {
        button.onClick.AddListener(Close);
    }

    private void Close()
    {
        button.onClick.RemoveListener(Close);
        Application.Quit();
    }
}
