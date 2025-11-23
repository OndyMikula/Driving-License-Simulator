using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class speedLimit : MonoBehaviour
{
    public gameController gameC;
    public carController carC;
    public int SpeedLimit;

    void Start()
    {
        gameC = FindAnyObjectByType<gameController>();
        carC = FindAnyObjectByType<carController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SpeedLimit = 53;
    }
}
