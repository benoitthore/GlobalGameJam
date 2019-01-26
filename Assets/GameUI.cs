using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreComponentText;
    public Text currencyComponentText;

    private int score;
    private int currency;

    private void Start()
    {
        SetScore(PlayerController.instance.score);
        SetCurrency(PlayerController.instance.currency);
    }

    private void Update()
    {
        if (currency != PlayerController.instance.currency)
        {
            SetCurrency(PlayerController.instance.currency);
        }

        if (score != PlayerController.instance.score)
        {
            SetCurrency(PlayerController.instance.score);
        }
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        scoreComponentText.text = "Score: " + newScore;
    }

    public void SetCurrency(int newCurrency)
    {
        currency = newCurrency;
        currencyComponentText.text = "Currency: " + newCurrency;
    }
}
