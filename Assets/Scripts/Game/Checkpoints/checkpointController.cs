using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkpointController : MonoBehaviour
{
    public gameController gameC; // musí bejt public
    public carController carC; // musí bejt public

    public bool checkpointActive1 = false;
    public bool checkpointActive2 = false;

    private void Update()
    {
        if (checkpointActive1 == true && checkpointActive2 == true)
        {
            gameC.Canvas_Success.SetActive(true);
            gameC.Canvas_Checkpoint.SetActive(false);
            gameC.successScoretxt.text = $"Počet skóre: {gameC.score}";
        }
        else if (checkpointActive1 == true)
        {
            gameC.Canvas_Checkpoint.SetActive(true);
            gameC.scoretxt.text = $"Počet skóre: {gameC.score}";
        }
        else if (checkpointActive1 == false && checkpointActive2 == true)
        {
            gameC.Canvas_Success.SetActive(true);
            gameC.successScoretxt.text = $"Počet skóre: {gameC.score}";
        }
    }
}
