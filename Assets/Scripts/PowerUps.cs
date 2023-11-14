using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PowerUps : MonoBehaviour {
    Rigidbody2D rigidbody2d;

    public delegate void PowerUpDelegate(PowerUp powerUp);
    public event PowerUpDelegate PowerUpEvent;

    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = new Vector2(0, -1);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);

        PowerUpEvent?.Invoke(new PowerUp());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }
}
