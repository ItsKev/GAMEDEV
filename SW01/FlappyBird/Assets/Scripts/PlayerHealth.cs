using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent PlayerDeathEvent = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.PlayerDeathEvent.Invoke();
    }
}