using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Vector3 offset;
    private Vector3 original;

    // Use this for initialization
    private void Start()
    {
        var position = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;

        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = ball.transform.position + offset;
    }
}