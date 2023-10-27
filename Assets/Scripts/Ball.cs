using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    Rigidbody2D rigidbody2d;
    public Vector2 initialVelocity = Vector2.up;

    private void Awake() {
        // Get the rigidbody of the ball
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Start() {
        // set initial velocity of the ball to start the game
        rigidbody2d.velocity = initialVelocity;
    }

    void Update() {

    }
}
