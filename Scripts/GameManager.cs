using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator animator;
    public bool isStart = false;
    public int level = 0;
    public int money = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
    }
    public void StartGame()
    {
        isStart = true;
        animator.SetInteger("state", 1);
        SoundManager.Instance.PlaySteps();
    }

    public void EndGame()
    {
        isStart = false;
        animator.SetInteger("state", 2);
        SoundManager.Instance.StopSounds();
        //fail ekraný
    }
    public void Win()
    {
        isStart = false;
        animator.SetInteger("state", 3);
        SoundManager.Instance.StopSounds(); // w,n sesi ekle
        //ui manager dan win ekraný getir.
        NextLevel();
        SaveMoney(UIManager.Money);

    }

    public void NextLevel()
    {
        level = PlayerPrefs.GetInt("level");
        level++;
        PlayerPrefs.SetInt("level", level);
    }

    public void SaveMoney(int addMoney)
    {
        PlayerPrefs.SetInt("money", addMoney);
    }
}
