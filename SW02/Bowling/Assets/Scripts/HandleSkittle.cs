using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSkittle : MonoBehaviour
{

    public event EventHandler SkittleFallenEvent;

    private bool collidedAlready;

	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!collidedAlready)
        {
            collidedAlready = true;
            StartCoroutine(CheckIfSkittleStillStanding());
        }
    }

    private IEnumerator CheckIfSkittleStillStanding()
    {
        yield return new WaitForSeconds(6);
        if (Math.Abs(transform.rotation.x) > 0.1 || Math.Abs(transform.rotation.z) > 0.1)
        {
            Destroy(gameObject);
            var handler = SkittleFallenEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        else
        {
            collidedAlready = false;
        }
    }

}
