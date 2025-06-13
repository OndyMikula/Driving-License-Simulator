using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Arrow : MonoBehaviour
{
    public string targetName = "Crossover #1";
    private Transform cil; // reference na cil, kam ma sipka ukazovat
    public Vector3 vyskaNadAutem = new Vector3(0, 2, 0); // Výška nad autem
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject checkpoint = GameObject.Find("Crossover #1");

        //if (checkpoint != null)
        //    cil = checkpoint.transform;
        GameObject targetObj = GameObject.Find(targetName); //hledame checkpoint 
        if (targetObj != null)
            cil = targetObj.transform;
        else
            Debug.LogWarning("Nemůžu najít objekt podle jména: " + targetName);

        if (player == null) //pro zmenu player obejctu nastavit tag na jiny object v inspectoru
        {
            GameObject found = GameObject.FindWithTag("Player");
            if (found != null)
            {
                player = found.transform;
            }
            else
            {
                Debug.LogWarning("Player není nastavený ani nalezený!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = vyskaNadAutem; // nastavime fixnutou pozici sipky nad autem
        Debug.Log("Souradnice sipky: " + transform.localPosition); //pro testing

        if (cil != null)
        {
            // nastavime rotaci sipky tak, aby smerovala k cili
            Vector3 direction = cil.position - transform.position;
            direction.y = 0f; // ignoruj výškový rozdíl
            transform.position = player.position + vyskaNadAutem; // nastavime pozici sipky na hrace

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion rot = Quaternion.LookRotation(direction); //vypocita otoceni sipky tak, aby smerovala k cili
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 5f); // plynule otaceni sipky
            }
        }
        else
        {
            Debug.LogWarning("Cil pro sipku neni nastaven!");
        }
    }
}
