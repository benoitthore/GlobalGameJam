using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreComponentText;
    public Text currencyComponentText;
    public Healthbar healthbarComponent;

    private int score;
    private int currency;
    private float health = 1f;

    private void Start()
    {
        SetScore(PlayerController.instance.score);
        SetCurrency(PlayerController.instance.currency);
        healthbarComponent.SetHealth(100); // Set actual health
    }

    private void Update()
    {
        if (score != PlayerController.instance.score)
        {
            SetScore(PlayerController.instance.score);
        }

        if (currency != PlayerController.instance.currency)
        {
            SetCurrency(PlayerController.instance.currency);
        }

        var earthHealth = GameController.instance.earth.GetComponent<Health>();
        if (health != earthHealth.getHealth())
        {
            healthbarComponent.SetHealth(earthHealth.getHealth() / earthHealth.getMaxHealth());
        }
    }

    public void SetScore(int newScore)
    {
        if (newScore > 9999999) return;

        score = newScore;
        scoreComponentText.text = newScore.ToString("D7");
    }

    public void SetCurrency(int newCurrency)
    {
        if (newCurrency > 999999) return;

        currency = newCurrency;
        currencyComponentText.text = newCurrency.ToString("D6") + "$";
    }
}