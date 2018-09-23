using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject cylinderPrefab;

    [SerializeField] private GameObject startGameText;

    [SerializeField] private Text deathText;

    private Rigidbody playeRigidbody;
    private PlayerMovement playerMovement;
    private bool gameStarted = false;
    private bool gameOver = false;
    private float spawnRate = 1.5f;
    private float timer;
    private bool spawnTop = false;
    private List<GameObject> cylinders = new List<GameObject>();
    private int cylinderCounter = 0;

    private void Start()
    {
        this.playeRigidbody = this.player.GetComponent<Rigidbody>();
        this.playeRigidbody.isKinematic = true;

        this.playerMovement = this.player.GetComponent<PlayerMovement>();

        var playerHealth = this.player.GetComponent<PlayerHealth>();
        playerHealth.PlayerDeathEvent.AddListener(OnPlayerDeath);

        this.timer = 0f;

        for (var i = 0; i < 5; i++)
        {
            this.cylinders.Add(Instantiate(this.cylinderPrefab, new Vector3(-20, -20, 0), Quaternion.identity));
        }
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!gameOver && !this.gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            this.gameStarted = true;
            this.playeRigidbody.isKinematic = false;
            this.startGameText.SetActive(false);
            this.deathText.enabled = false;
            this.playerMovement.GameStarted = true;
        }

        if (this.gameStarted)
        {
            this.timer -= Time.deltaTime;
            if (this.timer <= 0)
            {
                var position = this.cylinderPrefab.transform.position;
                if (!this.spawnTop)
                {
                    this.spawnTop = true;
                    position.y = -4;
                }
                else
                {
                    this.spawnTop = false;
                }

                var cylinder = this.cylinders[this.cylinderCounter];
                cylinder.transform.position = position;
                cylinder.GetComponent<CylinderMovement>().GameStarted = true;
                cylinderCounter++;
                if (cylinderCounter >= 5)
                {
                    cylinderCounter = 0;
                }

                this.timer = this.spawnRate;
            }
        }
    }

    private void OnPlayerDeath()
    {
        this.gameStarted = false;
        this.playerMovement.GameStarted = false;

        var deathSound = GetComponent<AudioSource>();
        deathSound.Play();

        foreach (var cylinder in this.cylinders)
        {
            cylinder.GetComponent<CylinderMovement>().GameStarted = false;
        }

        this.playeRigidbody.isKinematic = true;
        this.playeRigidbody.velocity = Vector3.zero;
        this.playeRigidbody.angularVelocity = Vector3.zero;

        this.timer = 0f;

        this.deathText.enabled = true;
        this.startGameText.SetActive(true);
        this.gameOver = true;
    }
}