using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickContainer : MonoBehaviour {
    [SerializeField] private GameObject brickPrefab;
    private char[,] bricks = new char[11, 10];
    private int BrickAmount;
    private TextAsset level;

    private void Awake() {
        LoadLevel();
        SetPositionOfAllBricks();
    }

    private void LoadLevel() {
        level = Resources.Load<TextAsset>("level000");
        char[] type = level.text.ToCharArray();
        int y = 0;
        for (int x = 0; x < type.Length; x++) {
            if (type[x] == type[10]) {
                y++;
            } else if (type[x] == type[11]) {
                continue;
            } else {
                bricks[y, x % 10] = type[x];
            }
        }
    }

    private GameObject FindType(char c) {
        if (c == '#') {
            return brickPrefab;
        } else {
            return null;
        }
    }

    private Brick SpawnBrick(GameObject brick, Vector3 cords) {
        GameObject temp = null;
        if (brick != null) { 
            temp = Instantiate(brick, cords, Quaternion.identity, transform);
            return temp.GetComponent<Brick>();
        }
        return null;
    }

    private void SetPositionOfAllBricks() {
        for (int y = 0; y < bricks.GetLength(0); y++) {
            for (int x = 0; x < bricks.GetLength(1); x++) {
                SpawnBrick(FindType(bricks[y, x]), new Vector3(((x + 1) * 0.6f) - 3.3f, ((y + 1) * 0.25f) + 1.2f, 0));
            }
        }
    }

    private void CheckBricks() {
        
    }
}
