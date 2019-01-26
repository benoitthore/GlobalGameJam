using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    /*TODO (resolutions):
     1024×576, 1152×648, 1280×720, 1366×768, 1600×900, 1920×1080
     */
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GoToMenu();
        }
    }

    public void Apply()
    {
        // Write option values
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
