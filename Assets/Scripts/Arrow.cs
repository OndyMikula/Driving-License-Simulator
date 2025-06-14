using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    public Transform target;
    public float arrowSpeed;

    private RectTransform arrowRect;

    void Start()
    {

    }

    void Update()
    {
        // Výpočet směru bez výšky
        Vector3 dir = target.position - transform.position;
        dir.y = 0;

        if (dir.sqrMagnitude > 0.001)
        {
            Quaternion rot = Quaternion.LookRotation(dir);

            rot *= Quaternion.Euler(0, 90, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10);
        }
    }
}
