using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Nastavte tag "Player" na vaše auto
        {
            Checkpointy.Instance.CheckpointReached(transform);
        }
    }
}
