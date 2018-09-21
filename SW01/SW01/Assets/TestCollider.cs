using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    private Material material;
    private Rigidbody _rigidbody;
    private bool gPressed = false;
    [SerializeField]
    private int _health = 3;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        this.material = GetComponent<Renderer>().material;
        this._rigidbody = GetComponent<Rigidbody>();
        this.startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F pressed");
            this._rigidbody.velocity = new Vector3(0, 10, 0);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (this.gPressed)
            {
                this.gPressed = false;
                this._rigidbody.useGravity = true;
            }
            else
            {
                this.gPressed = true;
                this._rigidbody.useGravity = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.gameObject.transform.position = this.startPosition;
        }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        this.material.color = Random.ColorHSV();
        this._health--;
        if (this._health <= 0)
        {
            Destroy(gameObject);
        }
    }


}