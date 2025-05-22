using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action WPressed;
    public event Action DPressed;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            WPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.D))
            DPressed?.Invoke();
    }
}
