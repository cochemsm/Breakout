using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {
    public delegate void BrickHitDelegate(Brick brickThatWasHit);
    public event BrickHitDelegate OnBrickHit;
    GameObject MySceneManager;

    private void Awake() {
        MySceneManager = GameObject.Find("MySceneManager");
        MySceneManager.GetComponent<MySceneManager>().AddBrick();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        MySceneManager.GetComponent<MySceneManager>().BrickBroken();
        Destroy(gameObject);
        OnBrickHit?.Invoke(this);
    }
}