using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI levelText;

    public static int Money;

    void Start()
    {
        LoadMoney();
        ShowLevelText();
    }


    void Update()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        ScoreText.text = "MONEY:  " + Money.ToString();
    }

    public void LoadMoney()
    {
        Money = PlayerPrefs.GetInt("money");
        ShowScore();
    }

    public static void ResetValues()
    {
        Money = 0;
    }

    public void ShowLevelText()
    {
        levelText.text = (PlayerPrefs.GetInt("level")+1).ToString();
    }
}
