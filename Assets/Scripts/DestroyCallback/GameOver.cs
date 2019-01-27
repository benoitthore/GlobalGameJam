using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    private void Start()
    {
        gameOverScreen.ToggleScreen(true);
    }

    private void Update()
    {
        Debug.Log("GameOver");
    }
}
