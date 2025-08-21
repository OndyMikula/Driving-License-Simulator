using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger2 : MonoBehaviour
{
    public gameController gameC; // musí bejt public
    public checkpointController checkpointC; // musí bejt public

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointC.checkpointActive2 = true;
            gameC.score += 10;
        }
    }
}
