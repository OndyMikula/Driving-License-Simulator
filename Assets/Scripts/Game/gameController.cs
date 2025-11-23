using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public carController carC;
    public BtnManager btnManager;
    public speedLimit speedL;

    public int score = 0;

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
            Canvas_FailText.text = "Porušil jsi závažný přečin, začni znovu";
        }
        if (carC.currentSpeed >= speedL.SpeedLimit)
        {
            score -= 10;
            Canvas_FailText.text = "Jel jsi moc rychle";
            Canvas_Fail.enabled = true;
        }
    }
}