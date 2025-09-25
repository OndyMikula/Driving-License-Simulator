using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllTrafficSignal : MonoBehaviour
{
    public gameController gameC; // musí bejt public

    public BoxCollider boxCollider;
    public CapsuleCollider capsuleCollider;

    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    // Start is called before the first frame update
    void Start()
    {
        redLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);

        boxCollider.enabled = true;
        capsuleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameC.Canvas_Fail.SetActive(true);
            /*// Změna na zelenou
            redLight.SetActive(false);
            yellowLight.SetActive(true);
            greenLight.SetActive(false);
            boxCollider.enabled = false;
            capsuleCollider.enabled = true;
            StartCoroutine(ChangeToGreen());*/
        }
    }

     void OnCollisionEnter(Collision dataFromCollision)
     {
         if (dataFromCollision.gameObject.tag == "Player")
         {
            //Do whatever you want 
         }
     }
}
