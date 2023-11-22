using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickContainer : MonoBehaviour {
    [SerializeField] private GameObject brickPrefab;
    private List<Brick> bricks;
    private int BrickAmount;
    private TextAsset level;

    private void Awake() {
        LoadLevel();
        SetPositionOfAllBricks();
    }

    private void LoadLevel() {
        level = Resources.Load<TextAsset>("level000");
        char[] type = level.text.ToCharArray();
        foreach (char c in type) {
            bricks.Add(SpawnBrick(FindType(c), new Vector3(0, 0, 0)));
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
            temp = Instantiate(brick, cords , Quaternion.identity, transform);
            return temp.GetComponent<Brick>();
        }
        return null;
    }

    private void SetPositionOfAllBricks() {
        int i = 0;
        for (int y = 0; y < 11; y++) {
            for (int x = 0; x < 10; x++) {
                bricks[i].gameObject.transform.position = new Vector3(((x + 1) * 0.6f) - 3.3f, ((y + 1) * 0.25f) + 1.2f, 0);
                i++;
            }
        }
    }

    private void CheckBricks() {
        
    }
}
