using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float MoveSpeed { get; set; }
    public bool GameStarted { get; set; }

    // Use this for initialization
    private void Start()
    {
        this.MoveSpeed = 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameStarted)
        {
            gameObject.transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}