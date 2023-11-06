using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    Rigidbody2D rigidbody2d;
    private Vector3 initialPosition;
    private bool move = false;

    GameObject MySceneManager;

    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        MySceneManager = GameObject.Find("MySceneManager");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Rigidbody2D>()) {
            rigidbody2d.velocity = (rigidbody2d.velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity).normalized * rigidbody2d.velocity.magnitude;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.position = initialPosition;
        MySceneManager.GetComponent<MySceneManager>().LifeLost();
        move = false;
    }

    public void BallStart() {
        rigidbody2d.velocity = new Vector2(Random.Range(-10f, 10f), 4);
        move = true;
    }

    private void FixedUpdate() {
        if (move && (rigidbody2d.velocity.y == 0)) {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -3);
        }
        if (move && (rigidbody2d.velocity.x == 0)) {
            rigidbody2d.velocity = new Vector2(Random.Range(-1f, 1f), rigidbody2d.velocity.y);
        }
    }
}