using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger1 : MonoBehaviour
{
    public gameController gameC; // musí bejt public
    public checkpointController checkpointC; // musí bejt public

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointC.active1 = true;
            gameC.paused = true;
            gameC.Canvas_UncompletedText.text = "Gratuluji, dosáhl jsi prvního checkpointu!\n" +
                                                    "Pokračuj dál v jízdě.";
            gameC.Uncompleted();
            gameC.score += 10;
        }
    }
}
