using UnityEngine;

public class Brick : MonoBehaviour {
    public delegate void BrickHitDelegate(Brick brickThatWasHit);
    public event BrickHitDelegate OnBrickHit;

    private void Awake() {
        GameManager.Instance.AddBrick();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroyBrick();
    }

    public void DestroyBrick() {
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        transform.DetachChildren();

        GameManager.Instance.BrickBroken();
        Destroy(gameObject);
        OnBrickHit?.Invoke(this);
    }
}