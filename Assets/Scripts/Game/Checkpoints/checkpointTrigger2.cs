using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger2 : MonoBehaviour
{
    public gameController gameC; // mus� bejt public
    public checkpointController checkpointC; // mus� bejt public

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointC.checkpointActive2 = true;
            gameC.score += 10;
        }
    }
}
