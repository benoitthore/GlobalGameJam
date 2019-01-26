﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public int score = 0;
    public int currency = 0;
    public Text scoreComponentText;
    public Text currencyComponentText;

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
