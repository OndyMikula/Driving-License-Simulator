using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public carController carC; // musí bejt public

    public GameObject Canvas_Fail;
    public GameObject Canvas_Success;
    public GameObject Canvas_Checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        Canvas_Fail = GameObject.Find("Canvas_Fail");
        Canvas_Success = GameObject.Find("Canvas_Success");
        Canvas_Checkpoint = GameObject.Find("Canvas_Checkpointy");

        Canvas_Checkpoint.SetActive(false);
        Canvas_Fail.SetActive(false);
        Canvas_Success.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Moc rychlá jízda byebye
        if (carC.currentSpeed >= 25)
        {
            Canvas_Fail.SetActive(true);
        }
    }
}
