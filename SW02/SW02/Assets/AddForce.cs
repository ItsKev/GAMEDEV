using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 100), ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
}
