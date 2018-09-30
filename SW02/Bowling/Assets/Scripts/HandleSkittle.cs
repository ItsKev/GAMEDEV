using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSkittle : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CheckIfSkittleStillStanding());
    }

    private IEnumerator CheckIfSkittleStillStanding()
    {
        yield return new WaitForSeconds(10);
        if (Math.Abs(transform.rotation.x) > 0.5 || Math.Abs(transform.rotation.z) > 0.5)
        {
            Destroy(gameObject);
        }
    }

}
