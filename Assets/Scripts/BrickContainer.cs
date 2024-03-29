using UnityEngine;

public class BrickContainer : MonoBehaviour {
    [SerializeField] private GameObject brickPrefab;
    private char[,] bricks = new char[10, 11];
    private TextAsset level;

    private void Awake() {
        LoadLevel(GameManager.Instance.CurrentLevel);    
    }

    public void LoadLevel(int levelNum) {
        string sceneName = "level00" + levelNum;
        level = Resources.Load<TextAsset>(sceneName);
        char[] type = level.text.ToCharArray();
        int y = 0;
        int x = 0;
        for (int i = 0; i < type.Length; i++) {
            if (type[i] == type[10] || type[i] == type[11]) {
                continue;
            }
            bricks[x, y] = type[i];
            x++;
            if (x >= bricks.GetLength(0)) {
                y++;
                x = 0;
            }
        }

        SetPositionOfAllBricks();
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
        for (int x = 0; x < bricks.GetLength(0); x++) {
            for (int y = 0; y < bricks.GetLength(1); y++) {
                SpawnBrick(FindType(bricks[x, y]), new Vector3(((x + 1) * 0.6f) - 3.3f, ((y + 1) * -0.25f) + 3.95f, 0));
            }
        }
    }
}
