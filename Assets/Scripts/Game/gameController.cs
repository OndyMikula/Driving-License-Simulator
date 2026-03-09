using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public carController carC;
    public BtnManager btnManager;
    public speedLimit speedL;
    public checkpointController checkpointC;

    public int score = 12;
    public int rulesSuccess = 0;
    public int rulesFail = 0;
    public bool paused = false;

    public TMP_Text scoretxt;
    public TMP_Text statsText;
    public TMP_Text Canvas_FailText;
    public TMP_Text Canvas_SuccessText;
    public TMP_Text Canvas_UncompletedText;
    //public TMP_Text Canvas_AchievementText;

    public Canvas Canvas_Fail;
    public Canvas Canvas_Success;
    //public Canvas Canvas_Achievement;
    public Canvas Canvas_Uncompleted;
    public Canvas Canvas_Stats;

    // Start is called before the first frame update
    void Start()
    {
        //Canvas_Achievement.enabled = false;
        Canvas_Fail.enabled = false;
        Canvas_Success.enabled = false;
        Canvas_Uncompleted.enabled = false;
        Canvas_Stats.enabled = false;

        statsText.enabled = false;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "Skóre: " + score;
        if (score < 0)
        {
            Fail();
        }
        if (carC.currentSpeed >= speedL.SpeedLimit)
        {
            rulesFail++;
            Fail();
        }
        if (checkpointC.finish)
        {
            Success();
        }
    }

    public void Fail()
    {
        if (paused) return; // Pokud je hra již pozastavena, nedělej nic
        rulesFail++;
        Canvas_Fail.enabled = true;
        Canvas_FailText.text = "Porušil jsi závažný přečin, začni znovu!";
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
        paused = true;
        Stats();
        Time.timeScale = 0f; // Zastaví čas, aby se hra "zastavila" a hráč mohl vidět výsledky
    }

    public void Success()
    {
        Canvas_Success.enabled = true;
        Canvas_SuccessText.text = "Úrověň dokončena!";
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
        paused = true;
        Stats();
        Time.timeScale = 0f;
    }
    
    public void Uncompleted()
    {
        Canvas_Uncompleted.enabled = true;
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
        paused = true;
        Time.timeScale = 0f;
    }

    void Stats()
    {
        Canvas_Stats.enabled = true;
        statsText.enabled = true;
        statsText.text = 
            $"Počet dodržených pravidel: {rulesSuccess}\n" +
            $"Počet porušených pravidel: {rulesFail}\n" +
            $"Celkové skóre: {score}";
    }

    /*public void Achievement() //potreba udelat timer na zobrazeni
    {
        Canvas_Achievement.enabled = true;
        Canvas_AchievementText.fontSize = 24;
    }*/
}