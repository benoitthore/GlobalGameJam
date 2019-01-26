using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public const float speedMultiplier = 100f;

    [TagSelector] public string[] tagPlayerFilter;
    [TagSelector] public string[] tagEnemyFilter;
    
    private void Awake()
    {
        instance = this;
    }

    public static bool isObjectFromTag(GameObject gameObject, string[] tags)
    {
        foreach (var _tag in tags)
        {
            if (gameObject.CompareTag(_tag))
            {
                return true;
            }
        }

        return false;
    }
}