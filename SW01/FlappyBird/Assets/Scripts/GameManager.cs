using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject cylinderPrefab;

    [SerializeField] private GameObject startGameText;
    [SerializeField] private Text deathText;

    private Rigidbody playeRigidbody;
    private PlayerMovement playerMovement;
    private bool gameStarted = false;
    private float spawnRate = 1.5f;
    private float timer;
    private bool spawnTop = false;

    private void Start()
    {
        this.playeRigidbody = this.player.GetComponent<Rigidbody>();
        this.playeRigidbody.useGravity = false;

        this.playerMovement = this.player.GetComponent<PlayerMovement>();

        var playerHealth = this.player.GetComponent<PlayerHealth>();
        playerHealth.PlayerDeathEvent.AddListener(OnPlayerDeath);

        this.timer = 0f;
    }

    private void Update()
    {
        if (!this.gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            this.gameStarted = true;
            this.playeRigidbody.useGravity = true;
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

                Instantiate(this.cylinderPrefab, position, this.cylinderPrefab.transform.rotation);
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

        foreach (var gameObjectInScene in FindObjectsOfType<GameObject>())
        {
            if (gameObjectInScene.CompareTag("Cylinder"))
            {
                Destroy(gameObjectInScene);
            }
        }

        this.playeRigidbody.useGravity = false;
        this.playeRigidbody.velocity = new Vector3(0f, 0f, 0f);
        this.playeRigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
        this.player.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        this.player.transform.position = new Vector3(0f, 0f, 0f);

        this.timer = 0f;

        this.deathText.enabled = true;
        this.startGameText.SetActive(true);
    }
}