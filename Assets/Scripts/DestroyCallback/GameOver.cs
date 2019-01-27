using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject gameOverScreenObject;
    public GameOverScreen gameOverScreenScript;

    private void Start()
    {
        // Freeze everything in the bg
        Time.timeScale = 0f;

        gameUI.SetActive(false);
        gameOverScreenObject.SetActive(true);
        gameOverScreenScript.SetScore(PlayerController.instance.score);
    }
}
