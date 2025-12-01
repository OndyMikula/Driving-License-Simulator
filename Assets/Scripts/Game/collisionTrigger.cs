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
        gameC.Fail();
        gameC.score -= 3;
        gameC.rulesFail += 1;
    }
}
