using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    // load first level when play button is pressed
    public void Play() {
        GameManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // close game when quit button is pressed
    public void Quit() {
        Application.Quit();
    }
}
