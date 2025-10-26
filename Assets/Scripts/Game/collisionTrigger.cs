using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll : MonoBehaviour
{
    public gameController gameC; // musí bejt public

    void Start()
    {
        gameC = FindAnyObjectByType<gameController>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        gameC.Canvas_Fail.SetActive(true);
    }
}
