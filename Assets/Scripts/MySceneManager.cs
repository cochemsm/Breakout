using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MySceneManager : MonoBehaviour {
    private int activeBricks = 0;
    private int score = 0;
    private int lives = 3;

    private TMP_Text scoreText;
    private TMP_Text livesText;
    private TMP_Text lostText;
    private TMP_Text respawnText;

    private GameObject ball;

    private bool respawn = true;
    private bool death = false;

    private void Update() {
        if (!CheckRefrences()) {
            FindRefrences();
        }

        if (Input.GetKeyDown(KeyCode.Space) && respawn) {
            ball.GetComponent<Ball>().BallStart();
            respawn = false;
            respawnText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Space) && death) {
            death = false;
            ResetLives();
            ResetBricks();
            ResetScore();
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BrickBroken() {
        score++;
        scoreText.text = score.ToString();
        activeBricks--;
        if (activeBricks == 0) {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddBrick() {
        activeBricks++;
    }

    private void ResetBricks() {
        activeBricks = 0;
    }

    private void FindRefrences() {
        // use tags?
        scoreText = GameObject.Find("Canvas/Score").GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
        livesText = GameObject.Find("Canvas/Lives").GetComponent<TMP_Text>();
        livesText.text = lives.ToString();

        lostText = GameObject.Find("Canvas/Lost").GetComponent<TMP_Text>();
        respawnText = GameObject.Find("Canvas/Respawn").GetComponent<TMP_Text>();

        ball = GameObject.Find("Ball");
    }

    private bool CheckRefrences() {
        // maybe change using a list

        if (scoreText == null) {
            return false;
        }
        if (livesText == null) {
            return false;
        }
        if (lostText == null) {
            return false;
        }
        if (respawnText == null) {
            return false;
        }
        if (ball == null) {
            return false;
        }

        return true;
    }

    private void ResetScore() {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void LifeLost() {
        lives--;
        livesText.text = lives.ToString();
        if (lives == 0) {
            death = true;
            lostText.text = "You lost!";
            respawnText.text = "press space to retry";
        } else {
            respawn = true;
            respawnText.text = "press space to continue";
        }
    }

    private void ResetLives() {
        lives = 3;
    }

    public void LoadScene(int targetScene) {
        respawn = true;

        // check if target scene index is out of bounds
        if (targetScene >= SceneManager.sceneCountInBuildSettings) {
            targetScene = 0;
        }

        // reset brick count
        activeBricks = 0;

        // load target scene
        SceneManager.LoadScene(targetScene);

        FindRefrences();
    }
}