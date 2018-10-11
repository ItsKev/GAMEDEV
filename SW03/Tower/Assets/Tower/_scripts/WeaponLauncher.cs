﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    public event Action FireWeapons = delegate { };

    [SerializeField] private InputManager inputManager;

    private void Start()
    {
        inputManager.FireAllWeapons += InputManagerOnFireAllWeapons;
    }

    private void InputManagerOnFireAllWeapons()
    {
        FireWeapons();
    }
}