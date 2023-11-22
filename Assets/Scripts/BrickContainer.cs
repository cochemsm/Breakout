using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickContainer : MonoBehaviour {
    [SerializeField] private GameObject brickPrefab;
    private int BrickAmount;
    private TextAsset level;

    private void Awake() {
        LoadLevel();
    }

    private void LoadLevel() {
        level = Resources.Load<TextAsset>("level000");
        char[] type = level.text.ToCharArray();
        foreach (char c in type) {
            SpawnBrick(FindType(c), new Vector3(0, 0, 0));
        }
    }

    private GameObject FindType(char c) {
        if (c == '#') {
            return brickPrefab;
        } else {
            return null;
        }
    }

    private void SpawnBrick(GameObject brick, Vector3 cords) {
        if (brick != null) { 
            Instantiate(brick, cords , Quaternion.identity, transform);
        }
    }

    private void CheckBricks() {
        
    }
}
