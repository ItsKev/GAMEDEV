using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public bool GameStarted { get; set; }

    // Use this for initialization
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        GameStarted = false;

        var inputManager = FindObjectOfType<InputManager>();
        inputManager.SpacePressed += OnSpacePressed;
    }

    private void OnSpacePressed()
    {
        if (GameStarted)
        {
            myRigidbody.velocity = new Vector2(0, 5);
        }
    }
}