using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MySceneManager : MonoBehaviour {
    private int activeBricks = 0;
    private int score = 0;

    private TMP_Text scoreText;

    private void Update() {
        if (scoreText == null) {
            FindScoreText();
        }
    }

    public void BrickBroken() {
        score++;
        scoreText.text = score.ToString();
        activeBricks--;
        if (activeBricks == 0) {
            LoadNextScene();
        }
    }

    public void AddBrick() {
        activeBricks++;
    }

    public void ResetBricks() {
        activeBricks = 0;
    }

    public void FindScoreText() {
        scoreText = GameObject.Find("Canvas/Score").GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    public void ResetScore() {
        score = 0;
        scoreText.text = score.ToString();
    }

    // TODO: move this somewhere else
    public void LoadNextScene() {
        // determine current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // define target scene index
        int targetSceneIndex = currentSceneIndex + 1;

        // check if target scene index is out of bounds
        if (targetSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            targetSceneIndex = 0;
        }

        // reset brick count
        activeBricks = 0;

        // load target scene
        SceneManager.LoadScene(targetSceneIndex);
    }
}