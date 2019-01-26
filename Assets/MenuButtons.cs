using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    public void OnClickStart()
    {

    }

    public void OnClickOptions()
    {

    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
