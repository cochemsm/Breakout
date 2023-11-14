using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PowerUp_Rocket : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private GameObject[] bricks;
    private Transform target;
    public float speed;

    private void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        
    }

    private Transform FindNearestTransformAndSetVector() {
        Brick temp = null;
        float tempF = float.PositiveInfinity;
        foreach (var brick in bricks) {
            if (tempF > Vector2.Distance(brick.transform.position, transform.position)) {
                temp = brick.GetComponent<Brick>();
                tempF = Vector2.Distance(brick.transform.position, transform.position);
            }
        }
        rigidbody2d.velocity = speed * Vector2.up;
        return temp.transform;
    }

    private void FixedUpdate() {
        bricks = GameObject.FindGameObjectsWithTag("brick");
        target = FindNearestTransformAndSetVector();
        //Achtung Gerrit hat hier änderungen Vorgenommen. Keine Haftung.
        Vector2 targetdirection = target.position - transform.position;
        float angle = Mathf.Tan(targetdirection.y / targetdirection.x);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (rigidbody2d.velocity.magnitude < 1) rigidbody2d.velocity = rigidbody2d.velocity.normalized * 5f;
        rigidbody2d.velocity = (rigidbody2d.velocity + (Vector2) (target.position - transform.position)).normalized * rigidbody2d.velocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "brick") {
            Destroy(gameObject);
        }
    }
}
