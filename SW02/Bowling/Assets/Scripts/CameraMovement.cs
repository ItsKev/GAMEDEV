using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Vector3 offset;
    private Vector3 original;
    private bool triggerEntered;

    public void ResetTriggerEntered()
    {
        triggerEntered = false;
    }

    // Use this for initialization
    private void Start()
    {
        var position = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;

        offset = transform.position - ball.transform.position;

        ball.GetComponent<PlayBall>().CameraTriggerEnteredEvent += OnCameraTriggerEnteredEvent;
    }

    private void OnCameraTriggerEnteredEvent(object sender, EventArgs e)
    {
        triggerEntered = true;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!triggerEntered)
        {
            transform.position = ball.transform.position + offset;
        }
    }
}