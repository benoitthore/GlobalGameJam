using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GoToMenu();
        }
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
