using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject gameOverScreenObject;
    public GameOverScreen gameOverScreenScript;

    private void Start()
    {
        gameUI.SetActive(false);
        gameOverScreenObject.SetActive(true);
        gameOverScreenScript.SetScore(PlayerController.instance.score);

        Time.timeScale = 0f;
    }

    private void Update()
    {
        Debug.Log("GameOver");
    }
}
