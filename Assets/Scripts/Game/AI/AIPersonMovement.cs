using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementPerson : MonoBehaviour
{
    //Trasa
    public List<Transform> route; // Seznam checkpointů
    public bool loop = true;      // Má jet po dojetí zase od prvního?

    //Nastavení chůze
    public float stopDistance = 3f; // Jak blízko k bodu musí dojít
    public float maxSpeed = 10f;    // Maximální rychlost chodce

    NavMeshAgent agent;
    int currentPointIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;

        if (route.Count > 0)
        {
            agent.SetDestination(route[currentPointIndex].position); //Nastavení bodů pro chodce
                                                                     //a kalkulace nejkratší trasy
        }
    }

    void Update()
    {
        if (route.Count == 0) 
            return;

        if (!agent.pathPending && agent.remainingDistance < stopDistance) //Kontrola příchodu k bodu
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        currentPointIndex++;

        if (currentPointIndex >= route.Count) //Kontrola příchodu k poslednímu bodu
        {
            if (loop == true)
                currentPointIndex = 0; // Pokud je nastaven loop, začne znovu od prvního bodu
            else return;
        }

        agent.SetDestination(route[currentPointIndex].position); //nastavení dalšího bodu pro chodce
    }
}