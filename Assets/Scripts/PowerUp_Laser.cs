using UnityEngine;

public class PowerUp_Laser : MonoBehaviour {
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        Collider2D col = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, LayerMask.GetMask("Brick")).collider;
        if (col is null) return;
        col.gameObject.GetComponent<Brick>().DestroyBrick();
    }
    
    private void Update() {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            DestroyLaser();
        }
    }

    private void DestroyLaser() {
        Destroy(gameObject);
    }
}