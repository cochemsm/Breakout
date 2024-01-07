using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager instance;
    public static AudioManager Instance => instance;
    private AudioSource source;

    [SerializeField] private AudioClip brickBreakSound;
    [SerializeField] private AudioClip collectPowerUp;
    [SerializeField] private AudioClip healthPickUp;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    public void PlayBrickBreakSoundEffect() {
        source.PlayOneShot(brickBreakSound);
    }

    public void PlayCollectPowerUpSoundEffect() {
        source.PlayOneShot(collectPowerUp);
    }

    public void PlayHealthPowerUpCollected() {
        source.PlayOneShot(healthPickUp);
    }
}
