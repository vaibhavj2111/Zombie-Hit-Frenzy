using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public float gameTime = 60f;
    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel;

    bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        if (gameEnded) return;

        gameTime -= Time.deltaTime;

        timerText.text = "Time: " + Mathf.Ceil(gameTime);

        if (gameTime <= 0)
        {
            EndGame();
        }
    }

    public void AddScore()
    {
        if (gameEnded) return;

        score++;
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        gameEnded = true;

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("Final Score: " + score);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}