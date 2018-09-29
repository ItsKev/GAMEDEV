using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBall : MonoBehaviour
{

    private Rigidbody rigbody;
    private bool spacePressed;
    private bool ballPlayed;

	// Use this for initialization
	private void Start ()
	{
	    rigbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        spacePressed = true;
	    }
	}

    private void FixedUpdate()
    {
        if (spacePressed && !ballPlayed)
        {
            ballPlayed = true;
            spacePressed = false;

            rigbody.AddForce(new Vector3(0, 0, 15), ForceMode.VelocityChange);
        }
    }


}
