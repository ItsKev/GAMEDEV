using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action FireAllWeapons = delegate { };

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FireAllWeapons();
        }
    }
}