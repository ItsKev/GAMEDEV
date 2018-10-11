using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayBall : MonoBehaviour
{
    public event EventHandler CameraTriggerEnteredEvent;

    [SerializeField] private float force = 15;
    private Rigidbody rigbody;
    private bool ballPlayed;
    private bool movePositionXPositive;

    public void ShootBall()
    {
        if (!ballPlayed)
        {
            ballPlayed = true;
            rigbody.AddForce(new Vector3(0, 0, force), ForceMode.VelocityChange);
        }
    }

    public void ChangeBallPosition(float speed)
    {
        if (movePositionXPositive)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            if (transform.position.x >= 1.5)
            {
                movePositionXPositive = false;
            }
        }
        else
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            if (transform.position.x <= -1.5)
            {
                movePositionXPositive = true;
            }
        }
    }

    public void ResetBallPlayed()
    {
        ballPlayed = false;
    }

    // Use this for initialization
    private void Start()
    {
        rigbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraTrigger"))
        {
            EventHandler handler = CameraTriggerEnteredEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}