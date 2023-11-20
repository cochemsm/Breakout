using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickContainer : MonoBehaviour {
    [SerializeField] private GameObject brickPrefab;
    private int BrickAmount;
    private TextAsset level;

    private void Awake() {
        level = Resources.Load<TextAsset>("level000");
    }

    private GameObject FindType() {
        char[] type = level.text.ToCharArray();
        foreach (char c in type) {
            if (c == '#') {
                return brickPrefab;
            } else {
                return null;
            }
        }
        return null;
    }

    private void SpawnBrick() {
        Instantiate(brickPrefab, Vector3.zero , Quaternion.identity, transform);
    }
}
