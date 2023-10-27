using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    // load first level when play button is pressed
    public void Play() {
        SceneManager.LoadScene(1);
    }

    // close game when quit button is pressed
    public void Quit() {
        Application.Quit();
    }
}
