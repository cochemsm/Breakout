using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    GameObject MySceneManager;

    private void Awake() {
        MySceneManager = GameObject.Find("MySceneManager");
    }

    // load first level when play button is pressed
    public void Play() {
        MySceneManager.GetComponent<MySceneManager>().LoadNextScene();
    }

    // close game when quit button is pressed
    public void Quit() {
        Application.Quit();
    }
}
