using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance => instance;

    private int activeBricks = 0;
    private int score = 0;
    private int lives = 3;

    private TMP_Text scoreText;
    private TMP_Text livesText;
    private TMP_Text lostText;
    private TMP_Text respawnText;

    private GameObject ball;
    private Player player;

    private bool respawn = true;
    private bool death = false;

    private PowerUps powerUp;
    public GameObject rocketPowerUpPrefab;
    public GameObject laserPowerUpPrefab;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }    

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (!CheckRefrences()) {
            FindRefrences();
        }

        if (Input.GetKeyDown(KeyCode.Space) && respawn) {
            ball.GetComponent<Ball>().BallStart();
            respawn = false;
            respawnText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Space) && death) {
            death = false;
            ResetLives();
            ResetBricks();
            ResetScore();
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (GameObject.FindGameObjectWithTag("powerUp") != null) {
            if (powerUp == null) {
                powerUp = GameObject.FindGameObjectWithTag("powerUp").GetComponent<PowerUps>();
                powerUp.PowerUpEvent += PowerUps_PowerUpEvent;
            }
        }
    }

    public void BrickBroken() {
        AudioManager.Instance.PlayBrickBreakSoundEffect();
        score++;
        scoreText.text = score.ToString();
        activeBricks--;
        if (activeBricks == 0) {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddBrick() {
        activeBricks++;
    }

    private void ResetBricks() {
        activeBricks = 0;
    }

    private void FindRefrences() {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("mainMenu")) {
            return;
        }

        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
        livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<TMP_Text>();
        livesText.text = lives.ToString();

        lostText = GameObject.FindGameObjectWithTag("Lost").GetComponent<TMP_Text>();
        respawnText = GameObject.FindGameObjectWithTag("Respawn").GetComponent<TMP_Text>();

        ball = GameObject.FindGameObjectWithTag("ball");
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }

    private bool CheckRefrences() {
        // maybe change using a list

        if (scoreText == null) {
            return false;
        }
        if (livesText == null) {
            return false;
        }
        if (lostText == null) {
            return false;
        }
        if (respawnText == null) {
            return false;
        }
        if (ball == null) {
            return false;
        }
        if (player == null) {
            return false;
        }

        return true;
    }

    private void ResetScore() {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void LifeLost() {
        lives--;
        livesText.text = lives.ToString();
        if (lives == 0) {
            death = true;
            lostText.text = "You lost!";
            respawnText.text = "press space to retry";
        } else {
            respawn = true;
            respawnText.text = "press space to continue";
        }
    }

    private void ResetLives() {
        lives = 3;
    }

    public void LoadScene(int targetScene) {
        respawn = true;

        // check if target scene index is out of bounds
        if (targetScene >= SceneManager.sceneCountInBuildSettings) {
            targetScene = 0;
        }

        // reset brick count
        activeBricks = 0;

        // load target scene
        SceneManager.LoadScene(targetScene);

        FindRefrences();
    }

    private void PowerUps_PowerUpEvent(PowerUp activePowerUp) {
        activePowerUp.activatePowerUp();
        if (activePowerUp.Type == PowerUp.typesOfPowerUps.Rocket) {
            Instantiate(rocketPowerUpPrefab, player.transform.position, Quaternion.identity);
        }
        if (activePowerUp.Type == PowerUp.typesOfPowerUps.Laser) {
            Instantiate(laserPowerUpPrefab, player.transform.position, Quaternion.identity);
        }
        if (activePowerUp.Type == PowerUp.typesOfPowerUps.Heart) {
            lives++;
            livesText.text = lives.ToString();
            player.PlayHearts();
            AudioManager.Instance.PlayHealthPowerUpCollected();
        }
    }
}