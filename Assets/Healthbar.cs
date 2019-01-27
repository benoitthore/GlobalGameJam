using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Transform innerBar;
    public Health health;
    private Vector3 originalScale;


    private void Start()
    {
        originalScale = innerBar.localScale;
    }

    private void Update()
    {
        if (health)
        {
            SetHealth(health.getHealth() / health.getMaxHealth());
        }
    }


    public void SetHealth(float value)
    {
        innerBar.localScale = new Vector3(value * originalScale.x, originalScale.y, originalScale.z);
    }
}