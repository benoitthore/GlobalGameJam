using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public RectTransform innerBar;

    public void SetHealth(float value)
    {
        innerBar.localScale = new Vector3(value , 1, 1);
    }
}
