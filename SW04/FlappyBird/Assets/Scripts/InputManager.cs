using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public event Action SpacePressed = delegate { };
    public event Action FireWeaponsPressed = delegate { };
	
	void Update () {
	    if (Input.GetKey(KeyCode.S))
	    {
	        FireWeaponsPressed();
	    }

	    if (Input.GetKey(KeyCode.Space))
	    {
	        SpacePressed();
	    }
	}
}
