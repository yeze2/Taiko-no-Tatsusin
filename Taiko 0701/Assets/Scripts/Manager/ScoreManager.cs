using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI perfect;
    public TextMeshProUGUI good;
    public TextMeshProUGUI miss;

    private int score = 0;
    private int perfectNum = 0;
    private int goodNum = 0;
    private int missNum = 0;

    private bool isPerfectOver = false;
    private bool isGoodOver = false;
    private bool isMissOver = false;

    private void Start()
    {
        playerScore.text = $"{score}";
        playerName.text = "noName";

        perfect.text = $"{perfectNum}";
        good.text = $"{goodNum}";
        miss.text = $"{missNum}";
    }

    private void Update()
    {
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        if (perfectNum < TimingManager.perfect)
        {
            perfectNum++;
            perfect.text = $"{perfectNum}";
            isPerfectOver = true;
        }
        if(isPerfectOver && goodNum < TimingManager.good)
        {
            goodNum++;
            good.text = $"{goodNum}";
            isGoodOver = true;
            if (goodNum == 0)
                isGoodOver = true;
        }
        if(isGoodOver && missNum < TimingManager.miss)
        {
            missNum++;
            miss.text = $"{missNum}";
            isMissOver = true;
            if (missNum == 0)
                isMissOver = true;
        }
        if(isMissOver && score < TimingManager.score)
        {
            score++;
            if (score > 10)
                score += 10;
            if (score > 100)
                score += 100;
            playerScore.text = $"{score}";
        }

    }
}
