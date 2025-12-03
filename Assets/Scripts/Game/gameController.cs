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

    public TMP_Text scoretxt;
    public TMP_Text successScoretxt;
    public TMP_Text Canvas_FailText;
    public TMP_Text Canvas_SuccessText;
    public TMP_Text Canvas_UncompletedText;

    public Canvas Canvas_Fail;
    public Canvas Canvas_Success;
    public Canvas Canvas_Checkpoint;
    public Canvas Canvas_Uncompleted;

    // Start is called before the first frame update
    void Start()
    {
        Canvas_Checkpoint.enabled = false;
        Canvas_Fail.enabled = false;
        Canvas_Success.enabled = false;
        Canvas_Uncompleted.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "Skóre: " + score;
        if (score < 0)
        {
            Fail();
            Canvas_FailText.text = "Porušil jsi závažný přečin, začni znovu! \n \n" +
                $"Počet dodržených pravidel: {rulesSuccess}\n" +
                $"Počet porušených pravidel: {rulesFail}\n" + 
                $"Celkové skóre: {score}";
            Canvas_FailText.fontSize = 15;
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
        Canvas_FailText.text = "Porušil jsi závažný přečin, začni znovu! \n \n" +
                $"Počet dodržených pravidel: {rulesSuccess}\n" +
                $"Počet porušených pravidel: {rulesFail}\n" + 
                $"Celkové skóre: {score}";
        Canvas_FailText.fontSize = 20;
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
        }

    public void Success()
        {
            Canvas_Success.enabled = true;
            Canvas_SuccessText.text = "Gratulujeme, dokončil jsi úroveň!\n \n" +
                $"Počet dodržených pravidel: {rulesSuccess}\n" +
                $"Počet porušených pravidel: {rulesFail}\n" + 
                $"Celkové skóre: {score}";
            Canvas_SuccessText.fontSize = 15;
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
    }

    public void Uncompleted()
    {
        Canvas_Uncompleted.enabled = true;
        carC.currentSpeed = 0;
        carC.maxSpeed = 0;
        carC.currentSpeedTxt.enabled = false;
        checkpointC.canvasActive = true;
    }
}