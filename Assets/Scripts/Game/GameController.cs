using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // dat mesto
    // chodce
    // krizovatky kde najednou prijedou 3 auta a ty musis vybrat v jakym poradi pojedou a system overi jestlis to udelal spravne nebo spatne
    // features: srazis chodce - bonusovy body
    //           nabouras do auta - bonusovy body
    //           nabouras do baraku - bonusovy body body
    //           nahodny npc bude zdenda a bude rikat KAPR S NIVOU
    //           schovas rl arenu kde budes moct realne hrat rocket league s boostem a skokem a micem a vsim
    //           na klavesu budes mit italskej brainrot nahodnej
    //           na klavesu budes mit nahodny hlasky zdendy
    //           na klavesu se objevi ptacek co bude nad tebou poletovat a bude rvat "Dobrý DEN"
    //           pri prujezdu okolo chodcu budes moct (treba na klavesu) rict Dobrý DEN a oni odpovi Ty čůráku deblní vole 
    //           budes sbirat zdenda coiny
    //           bude schovanej giga obrazek zdendy co kdyz ho najdes tak te bude honit pres celou mapu a furt se ti bude smat a rikat KAPR S NIVOU
    //           bude tam skrytej easter egg s kaprem a zdendou
    //           po narazu do baraku bude prehranej zvuk BYEBYE

    GameObject player;
    [SerializeField] GameObject[] DrivingLine;

    GameObject Canvas_Fail;
    GameObject Canvas_Success;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Canvas_Fail = GameObject.Find("Canvas_Fail");
        Canvas_Success = GameObject.Find("Canvas_Success");

        Canvas_Fail.SetActive(false);
        Canvas_Success.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (CarController.currentSpeed >= 6)
            Canvas_Fail.SetActive(true);*/

        if (Canvas_Fail == null || DrivingLine == null || DrivingLine.Length == 0)
            return;

        foreach (var line in DrivingLine)
        {
            var col = line.GetComponent<BoxCollider>();

            // Získání upravených hranic s bezpečnostní mezí
            Bounds bounds = new Bounds(col.bounds.center, col.bounds.size + Vector3.one * 0.1f);

            // Přesná detekce s vizualizací
            if (bounds.Contains(transform.position))
            {
                if (!Canvas_Fail.activeSelf)
                {
                    Canvas_Fail.SetActive(true);
                }
            }
        }

        /*if (DrivingLine != null && Canvas_Fail != null)
        {
            float distance = Vector3.Distance(transform.position, DrivingLine.transform.position);
            if (distance < 3) // Nastavte podle potřeby
            {
                Canvas_Fail.SetActive(true);
            }
        }*/
    }
}
