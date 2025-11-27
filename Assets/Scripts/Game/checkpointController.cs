using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkpointController : MonoBehaviour
{
    public gameController gameC; // musí bejt public
    public carController carC; // musí bejt public

    public bool active1 = false;
    public bool active2 = false;
    public bool finish = false;

    private void Update()
    {
        if (active1 == true && active2 == true)
        {
            finish = true;
            gameC.Canvas_Success.enabled = true;
            gameC.successScoretxt.text = $"Počet skóre: {gameC.score}";
        }
        else if (active1 == true)
        {
            gameC.Canvas_Checkpoint.enabled = true;
            gameC.scoretxt.text = $"Počet skóre: {gameC.score}";
        }
        else if (active1 == false && active2 == true)
        {
            finish = true;
            gameC.Canvas_Success.enabled = true;
            gameC.successScoretxt.text = $"Počet skóre: {gameC.score}";
        }
    }
}
