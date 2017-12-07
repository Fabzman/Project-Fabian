using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScripting : MonoBehaviour {

    public GUIText scoretext;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText startText;
    public GameObject PlayerCharacter;
    public bool HasDied;
    private int score;
    private bool gameOver;
    private bool restart;
    private bool start;



	// Use this for initialization
	void Start ()
    {
        // Sets all booleans to false and text to blank at startup, it also destroys the start text component after 2 seconds
        start = true;
        gameOver = false;
        restart = false;
        HasDied = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        startText.text = "Defend the Village";
        Destroy(startText, 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If player character game object is destroyed the has died bool will be true
        if (PlayerCharacter == null)
        {
            HasDied = true;
        }

        if (HasDied)
        {
            // Has died bool and gameover bool is set to true, text should play when has died is set to true but is not working properly
            gameOverText.text = "You Failed to Save the Village";
            gameOver = true;
        }

        if (gameOver)
        {
            // Game over bool and restart bool is true, text should play when game over bool is set to true but is not working properly
            restartText.text = "Press 'R' to Try Again";
            restart = true;
        }

        if (restart)
        {
            // Restart bool is true and when you press "R" you reload the level
            if (Input.GetKey(KeyCode.R))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
	}

    public void AddScore (int newScoreValue)
    {
        // Updates the score when an enemy is killed
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore ()
    {
        // Adds text to score when an enemy is killed
        scoretext.text = "Score: " + score;
    }
}
