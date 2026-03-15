using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class speedLimit : MonoBehaviour
{
    public int SpeedLimit;

    private void OnTriggerEnter(Collider other)
    {
        SpeedLimit = 53;
    }
}
