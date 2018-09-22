using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent PlayerDeathEvent = new UnityEvent();

    private void OnCollisionEnter(Collision collision)
    {
        this.PlayerDeathEvent.Invoke();
    }
}