using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject prefab;
    public float waitingTime = 2f;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        StartCoroutine(endGame());
    }

    IEnumerator endGame()
    {
        if (prefab)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(waitingTime);
        }

        gameOverScreen.SetActive(true);
    }
}