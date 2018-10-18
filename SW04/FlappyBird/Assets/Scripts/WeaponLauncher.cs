using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLauncher : MonoBehaviour {

    public event Action FireAllWeapons = delegate { };

    private void Start()
    {
        var inputManager = FindObjectOfType<InputManager>();
        inputManager.FireWeaponsPressed += OnFireWeaponsPressed;
    }

    private void OnFireWeaponsPressed()
    {
        FireAllWeapons();
    }
}
