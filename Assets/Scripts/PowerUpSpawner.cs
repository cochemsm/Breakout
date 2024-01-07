using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
    Brick brick;
    public GameObject powerUpPrefab;

    private void Awake() {
        brick = GetComponent<Brick>();
        if (brick != null) {
            brick.OnBrickHit += Brick_OnBrickHit;
        }
    }

    private void Brick_OnBrickHit(Brick brickThatWasHit) {
        int diceRoll = Random.Range(0, 6) + 1;
        if (diceRoll == 6) {
            SpawnPowerUp();
        }
        // SpawnPowerUp();
    }

    void SpawnPowerUp() {
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
    }
}
