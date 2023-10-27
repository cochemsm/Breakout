using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    Rigidbody2D rigidbody2d;
    private Vector3 initialPosition;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI lostText;
    [SerializeField] private TextMeshProUGUI respawnText;
    private bool respawn = true;
    private bool death = false;

    // TODO: move this somewhere else
    private int lives = 3;

    private void Awake() {
        // Get the rigidbody of the ball
        rigidbody2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Start() {
        // set initial velocity of the ball to start the game
        livesText.text = lives.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Rigidbody2D>()) {
            rigidbody2d.velocity = (rigidbody2d.velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity).normalized * rigidbody2d.velocity.magnitude;
        }
    }

    // action when ball falls below the player
    private void OnTriggerEnter2D(Collider2D collision) {
        lives--;
        livesText.text = lives.ToString();
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.position = initialPosition;
        if (lives == 0) {
            death = true;
            lostText.text = "You lost!";
            respawnText.text = "press space to retry";
        } else {
            respawn = true;
            respawnText.text = "press space to continue";
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && respawn) {
            rigidbody2d.velocity = new Vector2(Random.Range(-10f, 10f), 4);
            respawn = false;
            respawnText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Space) && death) {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate() {
        if (!respawn && !death && (rigidbody2d.velocity.y == 0)) {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -3);
        }
        if (!respawn && !death && (rigidbody2d.velocity.x == 0)) {
            rigidbody2d.velocity = new Vector2(Random.Range(-1f, 1f), rigidbody2d.velocity.y);
        }
    }
}