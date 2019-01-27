using UnityEngine;

public class DyingBonus : MonoBehaviour
{
    public int currency = 10;
    public int score = 10;

    private void OnDestroy()
    {
        var newMoney = PlayerController.instance.currency + currency;
        PlayerController.instance.SetCurrency(newMoney);
        var newScore = PlayerController.instance.score + score;
        PlayerController.instance.SetScore(newScore);
    }
}