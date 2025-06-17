using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointy : MonoBehaviour
{
    public static Checkpointy Instance;

    public List<Transform> checkpoints = new List<Transform>();
    private int currentCheckpointIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform GetCurrentCheckpoint()
    {
        if (currentCheckpointIndex < checkpoints.Count)
        {
            return checkpoints[currentCheckpointIndex];
        }
        return null; // Všechny checkpointy byly projeté
    }

    public void CheckpointReached(Transform checkpoint)
    {
        if (currentCheckpointIndex < checkpoints.Count &&
            checkpoint == checkpoints[currentCheckpointIndex])
        {
            currentCheckpointIndex++;
            Debug.Log($"Checkpoint {currentCheckpointIndex} reached! Next: {currentCheckpointIndex + 1}");
        }
    }

    public bool IsLastCheckpoint()
    {
        return currentCheckpointIndex >= checkpoints.Count;
    }
}
