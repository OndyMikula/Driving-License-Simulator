using UnityEngine;

public class IntersectionTrigger : MonoBehaviour
{
    public intersectionController intersectionC;
    public AICarController aiCarC;
    public carController carC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            carC.currentSpeed = 0;
            carC.maxSpeed = 0;

            intersectionC.StartMiniGame();
        }
    }
}