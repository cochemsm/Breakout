using UnityEngine;

public class PowerUp {
    public enum typesOfPowerUps {Rocket, Laser, Heart}
    public typesOfPowerUps Type { get; private set; }

    public PowerUp() {
        Type = (typesOfPowerUps) Random.Range(0, typesOfPowerUps.GetNames(typeof(typesOfPowerUps)).Length);
        Type = typesOfPowerUps.Heart;
    }

    public void activatePowerUp() {
        Debug.Log("Power Up activated. Power Up: " + Type);
    }
}
