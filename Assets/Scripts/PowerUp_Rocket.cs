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

        bricks = GameObject.FindGameObjectsWithTag("brick");
        target = FindNearestTransformAndSetVector();

        //Achtung Gerrit hat hier änderungen Vorgenommen. Keine Haftung.
        Vector2 targetdirection = target.position - transform.position;
        float angle = Mathf.Atan(targetdirection.y / targetdirection.x) * Mathf.Rad2Deg;
        if (angle > 0) {
            angle = 90f - angle;
        } else {
            angle = -90f - angle;
        }
        transform.rotation = Quaternion.Euler(0, 0, -angle);

        rigidbody2d.velocity = targetdirection * speed;
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

        return temp.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "brick") {
            ParticleSystem[] children = transform.GetComponentsInChildren<ParticleSystem>();
            foreach (var child in children) {
                child.Stop();
            }
            
            transform.DetachChildren();
            Destroy(gameObject);
        }



        // transform.GetComponent<SpriteRenderer>().enabled = false;
        // transform.GetComponent<ParticleSystem>().Stop();
    }
}
