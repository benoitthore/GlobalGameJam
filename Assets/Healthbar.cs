using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Transform innerBar;
    public Health health;
    private float originalScale;
    
    


    private void Start()
    {
        originalScale = innerBar.localScale.x;
    }

    private void Update()
    {
        SetHealth(health.getHealth() / health.getMaxHealth());
    }


    public void SetHealth(float value)
    {
        innerBar.localScale = new Vector3(value * originalScale, 1, 1);
    }
}