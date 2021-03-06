﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public bool GameStarted { get; set; }

    // Use this for initialization
    void Start()
    {
        this.myRigidbody = GetComponent<Rigidbody2D>();
        this.GameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && this.GameStarted)
        {
            this.myRigidbody.velocity = new Vector2(0, 5);
        }
    }
}