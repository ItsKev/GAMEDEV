using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngineInternal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject skittlePrefab;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject cam;

    [SerializeField] private Text score;
    [SerializeField] private Text gameEndedText;

    [SerializeField] private float leftRightSpeed = 0.5f;

    private List<Vector3> skittlePositions = new List<Vector3>();
    private PlayBall playBall;
    private Vector3 startPosition;

    private bool spacePressed;
    private bool positionSet;
    private int counter;
    private bool gameEnded;
    private bool restartGame;

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
        startPosition = ball.transform.position;

        foreach (var skittlePosition in skittlePositions)
        {
            var skittle = Instantiate(skittlePrefab, skittlePosition, Quaternion.identity);
            skittle.GetComponent<HandleSkittle>().SkittleFallenEvent += OnSkittleFallenEvent;
        }
    }

    private void OnSkittleFallenEvent(object sender, EventArgs e)
    {
        counter++;
        score.text = "Score: " + counter;
        if (counter >= 10)
        {
            gameEnded = true;
            restartGame = true;
            gameEndedText.enabled = true;
        }
    }

    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(8);
        if (!gameEnded)
        {
            var lightTrigger = GameObject.FindGameObjectsWithTag("LightTrigger");
            foreach (var gmObject in lightTrigger)
            {
                gmObject.GetComponent<LightTrigger>().DisableLight();
            }

            ball.transform.position = startPosition;
            ball.transform.rotation = Quaternion.identity;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            positionSet = false;
            cam.GetComponent<CameraMovement>().ResetTriggerEntered();
            playBall.ResetBallPlayed();
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
                StartCoroutine(StartNewRound());
            }

            if (restartGame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}