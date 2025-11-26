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

    public Canvas Canvas_Fail;
    public Canvas Canvas_Success;
    public Canvas Canvas_Checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        Canvas_Checkpoint.enabled = false;
        Canvas_Fail.enabled = false;
        Canvas_Success.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            Canvas_Fail.enabled = true;
            Canvas_FailText.text = "Porušil jsi závažný přečin, začni znovu! \n \n" +
                $"Počet dodržených pravidel: {rulesSuccess}\n" +
                $"Počet porušených pravidel: {rulesFail}\n" + 
                $"Celkové skóre: {score}";
            Canvas_FailText.fontSize = 15;
        }
        if (carC.currentSpeed >= speedL.SpeedLimit)
        {
            score -= 1;
            rulesFail += 1;
            Canvas_FailText.text = $"Jel jsi moc rychle, začni znovu! \n \n" +
                $"Počet dodržených pravidel: {rulesSuccess}\n" +
                $"Počet porušených pravidel: {rulesFail}\n" + 
                $"Celkové skóre: {score}";
            Canvas_SuccessText.fontSize = 15;
            Canvas_Fail.enabled = true;
        }
        if (checkpointC.finish)
        {
            Canvas_Success.enabled = true;
            Canvas_SuccessText.text = "Gratulujeme, dokončil jsi úroveň!\n \n" +
                $"Počet dodržených pravidel: {rulesSuccess}\n" +
                $"Počet porušených pravidel: {rulesFail}\n" + 
                $"Celkové skóre: {score}";
            Canvas_SuccessText.fontSize = 15;
            successScoretxt.text = $"Počet skóre: {score}";
        }
    }
}