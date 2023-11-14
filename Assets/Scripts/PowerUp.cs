using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp {
    public enum typesOfPowerUps {Rocket}
    public typesOfPowerUps Type { get; private set; }

    public PowerUp() {
        Type = (typesOfPowerUps) Random.Range(0, typesOfPowerUps.GetNames(typeof(typesOfPowerUps)).Length);
    }

    public void activatePowerUp() {
        Debug.Log("Power Up activated. Power Up: " + Type);
    }

    public void RocketPowerUp() {
        
    }
}
