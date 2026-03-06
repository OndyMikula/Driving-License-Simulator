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

    // Start is called before the first frame update
    void Start()
    {
        //Canvas_Achievement.enabled = false;
        Canvas_Fail.enabled = false;
        Canvas_Success.enabled = false;
        Canvas_Uncompleted.enabled = false;

        statsText.enabled = false;
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
        Canvas_Fail.enabled = true;
        Canvas_FailText.text = "Porušil jsi závažný přečin, začni znovu!";
        Stats();
        Canvas_FailText.fontSize = 20;
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
    }

    public void Success()
    {
        Canvas_Success.enabled = true;
        Canvas_SuccessText.text = "Gratulujeme, dokončil jsi úroveň!";
        Stats();
        Canvas_SuccessText.fontSize = 15;
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
    }
    
    public void Uncompleted()
    {
        Canvas_Uncompleted.enabled = true;
        Canvas_UncompletedText.text = "Gratuluji, dosáhl jsi prvního checkpointu!\n" +
                                        "Pokračuj dál v jízdě.";
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
        checkpointC.canvasActive = true;
    }

    void Stats()
    {
        statsText.enabled = true;
        statsText.text = $"Počet dodržených pravidel: {rulesSuccess}\n" +
            $"Počet porušených pravidel: {rulesFail}\n" +
            $"Celkové skóre: {score}";
    }

    /*public void Achievement() //potreba udelat timer na zobrazeni
    {
        Canvas_Achievement.enabled = true;
        Canvas_AchievementText.fontSize = 24;
    }*/
}