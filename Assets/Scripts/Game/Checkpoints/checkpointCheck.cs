using UnityEngine;

public class checkpointCheck : MonoBehaviour
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
            checkpointC.check = true;
            gameC.score += 10;
        }
    }
}
