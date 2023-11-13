using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private float input;
    [SerializeField] [Range(0,10)]private float speed = 4;

    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();    
    }

    private void Update() {
        input = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        rigidbody2d.velocity = new Vector2(input * speed, 0);


    }
}