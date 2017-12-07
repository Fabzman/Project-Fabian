using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject AxeShotSpawn;
    public GUIText scoretext;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText startText;
    public GameObject GameOver;
    public GameObject Restart;
    public bool HasDied;
    private int score;
    private bool gameOver;
    private bool restart;
    private bool start;

    void Start()
    {
        // Sets all booleans to false and text to blank when starting
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        HasDied = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // When PlayerCharacter hits an enemy it destroys him in the Hierarchy and sets HasDied bool and gameOver bool to true
            Destroy(PlayerCharacter);
            Destroy(AxeShotSpawn);
            HasDied = true;
            gameOver = true;
        }
    }

    void Update()
    {
        if (gameOver)
        {
            // When gameOver bool is true will set restart bool to true and play game over text
            GameOver.SetActive(true);
            gameOverText.text = "You Failed to Save the Village";
            restart = true;
        }

        if (restart)
        {
            Restart.SetActive(true);
        }
            if (Input.GetKey(KeyCode.R))
            {
                // When restart bool is true will allow player to restart level by pressing 'R" and will play restart text
                restartText.text = "Press 'R' to Try Again";
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }