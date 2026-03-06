using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointTrigger1 : MonoBehaviour
{
    public gameController gameC; // musí bejt public
    public checkpointController checkpointC; // musí bejt public

    void Start()
    {
        checkpointC = GetComponent<checkpointController>();
        gameC = GetComponent<gameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameC.paused = true;
            gameC.Uncompleted();
            gameC.score += 10;
        }
    }
}
