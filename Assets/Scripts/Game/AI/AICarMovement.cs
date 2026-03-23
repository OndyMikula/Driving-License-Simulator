using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICarController : MonoBehaviour
{
    //Trasa
    public List<Transform> route; // Seznam checkpointů v pravém pruhu
    public bool loop = true;      // Má jet po dojetí zase od prvního?

    //Nastavení jízdy
    public float stopDistance = 3f; // Jak blízko k bodu musí dojet (u auta radši víc)
    public float maxSpeed = 10f;    // Maximální rychlost auta

    NavMeshAgent agent;
    int currentPointIndex = 0;
    bool isStoppedByTraffic = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;

        if (route.Count > 0)
        {
            agent.SetDestination(route[currentPointIndex].position);
        }
    }

    void Update()
    {
        if (route.Count == 0) return;

        // Kontrola dojezdu k bodu
        if (!agent.pathPending && agent.remainingDistance < stopDistance)
        {
            MoveToNextPoint();
        }

        // Bonus: Tady můžeš ovládat zastavení (třeba na semaforu)
        agent.isStopped = isStoppedByTraffic;
    }

    void MoveToNextPoint()
    {
        currentPointIndex++;

        if (currentPointIndex >= route.Count)
        {
            if (loop == true)
                currentPointIndex = 0;
            else return;
        }

        agent.SetDestination(route[currentPointIndex].position);
    }

    // Tuhle funkci můžeš zavolat z jiného skriptu (např. detekce semaforu)
    public void SetTrafficStop(bool stop)
    {
        isStoppedByTraffic = stop;
    }

    // Tuhle metodu můžeš zavolat z triggeru křižovatky pro AI auta
    public IEnumerator SmoothStopAI(NavMeshAgent agent)
    {
        float startSpeed = agent.speed;
        float duration = 1.5f; // Jak dlouho má auto brzdit
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            agent.speed = Mathf.Lerp(startSpeed, 0, elapsed / duration);
            yield return null;
        }
        agent.speed = 0;
        agent.isStopped = true; // NavMesh agent se úplně zastaví
    }
}