using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {
    private static int activeBricks = 0;

    private void Awake() {
        activeBricks++;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        activeBricks--;
        if (activeBricks == 0) {
            LoadNextScene();
        }
        Destroy(gameObject);
    }

    // TODO: move this somewhere else
    void LoadNextScene() {
        // determine current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // define target scene index
        int targetSceneIndex = currentSceneIndex + 1;

        // check if target scene index is out of bounds
        if (targetSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            targetSceneIndex = 0;
        }

        // load target scene
        SceneManager.LoadScene(targetSceneIndex);
    }
}