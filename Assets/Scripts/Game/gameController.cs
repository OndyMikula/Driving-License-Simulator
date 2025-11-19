using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public carController carC;

    public int score = 0;

    public TMP_Text scoretxt;
    public TMP_Text successScoretxt;

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
        // Moc rychlá jízda byebye
        if (carC.currentSpeed >= 53)
        {
            Canvas_Fail.SetActive(true);
            score = 0;
        }
    }
}
