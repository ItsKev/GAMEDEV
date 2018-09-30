using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject skittlePrefab;
    [SerializeField] private GameObject ball;
    [SerializeField] private float leftRightSpeed = 0.5f;

    private List<Vector3> skittlePositions = new List<Vector3>();
    private PlayBall playBall;

    private bool spacePressed;
    private bool positionSet;

    // Use this for initialization
    private void Start()
    {
        skittlePositions.Add(new Vector3(0f, 0.3f, 12.6f));
        skittlePositions.Add(new Vector3(-0.4f, 0.3f, 13.3f));
        skittlePositions.Add(new Vector3(0.4f, 0.3f, 13.3f));
        skittlePositions.Add(new Vector3(-0.8f, 0.3f, 14f));
        skittlePositions.Add(new Vector3(0f, 0.3f, 14f));
        skittlePositions.Add(new Vector3(0.8f, 0.3f, 14f));
        skittlePositions.Add(new Vector3(-1.2f, 0.3f, 14.7f));
        skittlePositions.Add(new Vector3(-0.4f, 0.3f, 14.7f));
        skittlePositions.Add(new Vector3(0.4f, 0.3f, 14.7f));
        skittlePositions.Add(new Vector3(1.2f, 0.3f, 14.7f));

        playBall = ball.GetComponent<PlayBall>();

        foreach (var skittlePosition in skittlePositions)
        {
            Instantiate(skittlePrefab, skittlePosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (!positionSet)
        {
            playBall.ChangeBallPosition(leftRightSpeed);
        }

        if (spacePressed)
        {
            spacePressed = false;
            if (!positionSet)
            {
                positionSet = true;
                playBall.ShootBall();
            }
        }
    }
}