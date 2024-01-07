using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreakSoundEffect : MonoBehaviour{
    private static BrickBreakSoundEffect instance;
    public static BrickBreakSoundEffect Instance => instance;
    private AudioSource brickBreakSound;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        brickBreakSound = GetComponent<AudioSource>();
    }

    public void PlayBrickBreakSoundEffect() {
        brickBreakSound.Play();
    }
}
