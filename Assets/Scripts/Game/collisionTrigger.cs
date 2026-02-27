using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll : MonoBehaviour
{
    public gameController gameC;

    void Start()
    {
        gameC = FindAnyObjectByType<gameController>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameC.Fail();
            Debug.Log("Collided with " + other.gameObject.name);
        }
            
    }
}
