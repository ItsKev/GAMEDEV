using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject cylinderPrefab;

    private Rigidbody2D playeRigidbody;
    private PlayerMovement playerMovement;
    private UIManager uiManager;
    private bool gameStarted;
    private bool gameOver;
    private readonly float spawnRate = 1.5f;
    private int cylinderCounter;
    private float timer;
    private bool spawnTop;
    private readonly List<GameObject> cylinders = new List<GameObject>();
    private readonly Random random = new Random();

    private void Start()
    {
        var inputManager = GetComponent<InputManager>();
        inputManager.FireWeaponsPressed += OnFireWeaponsPressed;
        inputManager.SpacePressed += OnSpacePressed;

        playeRigidbody = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();

        var playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.PlayerDeath += OnPlayerDeath;

        uiManager = GetComponent<UIManager>();

        for (var i = 0; i < 5; i++)
        {
            cylinders.Add(Instantiate(cylinderPrefab, new Vector3(-20, -20, 0), Quaternion.identity));
        }
    }

    private void OnFireWeaponsPressed()
    {
    }

    private void OnSpacePressed()
    {
        if (gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (!gameStarted)
        {
            gameStarted = true;
            playeRigidbody.isKinematic = false;
            uiManager.ActivateText(false);
            playerMovement.GameStarted = true;
        }
    }

    private void OnPlayerDeath()
    {
        gameStarted = false;
        playerMovement.GameStarted = false;

        var deathSound = GetComponent<AudioSource>();
        deathSound.Play();

        foreach (var cylinder in cylinders)
        {
            cylinder.GetComponent<CylinderMovement>().GameStarted = false;
        }

        playeRigidbody.isKinematic = true;
        playeRigidbody.velocity = Vector2.zero;
        playeRigidbody.angularVelocity = 0;

        uiManager.ActivateText(true);
        gameOver = true;
    }

    private void FixedUpdate()
    {
        if (gameStarted)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnNewCylinder();
            }
        }
    }

    private void SpawnNewCylinder()
    {
        var position = cylinderPrefab.transform.position;
        if (!spawnTop)
        {
            spawnTop = true;
            position.y = random.Next(-5, -2);
        }
        else
        {
            spawnTop = false;
            position.y = random.Next(2, 5);
        }

        var cylinder = cylinders[cylinderCounter];
        cylinder.transform.position = position;
        cylinder.GetComponent<CylinderMovement>().GameStarted = true;
        cylinderCounter++;
        if (cylinderCounter >= 5)
        {
            cylinderCounter = 0;
        }

        timer = (float) (random.NextDouble() * 0.5 + spawnRate - 0.1);
    }
}