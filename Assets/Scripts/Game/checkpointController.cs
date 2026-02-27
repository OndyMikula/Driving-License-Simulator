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
    public bool check = false;
    public bool finish = false;
    public bool canvasActive = false;

    private void Update()
    {
        if (active1 == true && active2 == true && check == true)
        {
            finish = true;
        }
        else if (active1 == true && canvasActive == false)
        {
            gameC.Canvas_UncompletedText.text = "Získal jsi 1. checkpoint. Pokračuj v jízdě pomocí Resume";
            gameC.Uncompleted();
            canvasActive = false;
        }
        else if ((active1 == false && active2 == true) && canvasActive == false)
        {
            gameC.Uncompleted();
            gameC.Canvas_UncompletedText.text = "Minul jsi jeden z checkpointů. Vrať se a získej ho!";
        }

        /*if (active2 == true)
        {
            if (active1 == false)
            {
                gameC.Canvas_UncompletedText.text = "Minul jsi jeden z checkpointů. Vrať se a získej ho!";
                if (check == false)
                {
                    gameC.Uncompleted();
                    gameC.Canvas_UncompletedText.text = "Neprojel jsi celou trasu. Vrať se a tentokrát zkus nepodvádět. :)";
                }
            }
        }*/
    }
}
