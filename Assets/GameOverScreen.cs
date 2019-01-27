using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverScreen;

    public void OnRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnQuit()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
    }

    public void Update()
    {
        var playerInstance = PlayerController.instance;

        playerInstance.PlayGameOverMusic();
        playerInstance.ToggleUI(false);
        SetScore(playerInstance.score);

        Time.timeScale = 0;
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score.ToString("D7");
    }
}
