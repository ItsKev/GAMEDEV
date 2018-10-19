using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action FirePressed = delegate { };

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FirePressed();
        }
    }
}