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
        
    }

    private void Update()
    {
        healthbarComponent.health = GameController.instance.earth.GetComponent<Health>();
        if (score != PlayerController.instance.score)
        {
            SetScore(PlayerController.instance.score);
        }

        if (currency != PlayerController.instance.currency)
        {
            SetCurrency(PlayerController.instance.currency);
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