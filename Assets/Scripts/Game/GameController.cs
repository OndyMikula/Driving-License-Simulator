using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

    public TMP_Text scoretxt;
    int score = 0;

    GameObject player;
    [SerializeField] GameObject[] DrivingLine;
    [SerializeField] GameObject[] Checkpoint;

    GameObject Canvas_Checkpoint;
    GameObject Canvas_Fail;
    GameObject Canvas_Success;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        CanvasManager.FailCanvas = this.Canvas_Fail;
        CanvasManager.SuccessCanvas = this.Canvas_Success;
        CanvasManager.CheckpointCanvas = this.Canvas_Checkpoint;

        Canvas_Checkpoint.SetActive(false);
        Canvas_Fail.SetActive(false);
        Canvas_Success.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var line in DrivingLine)
        {
            var collider = line.GetComponent<BoxCollider>();

            // Získání upravených hranic s bezpečnostní mezí
            Bounds bounds = new Bounds(collider.bounds.center, collider.bounds.size + Vector3.one * 0.1f);

            // Přesná detekce s vizualizací
            if (bounds.Contains(transform.position))
            {
                Canvas_Fail.SetActive(true);
            }
        }

        if (player.transform.position.x >= 225 && player.transform.position.x <= 228 &&
            player.transform.position.z >= 246 && player.transform.position.z <= 247)
        {
            Canvas_Success.SetActive(true);
            scoretxt.text = $"Počet rizzu: {score}";
        }
        else if (player.transform.position.x >= 41 && player.transform.position.x <= 44 &&
                player.transform.position.z >= 134 && player.transform.position.z <= 138)
        {
            Canvas_Checkpoint.SetActive(true);
            score += 9999;
        }


        /*for (int i = 0; i < Checkpoint.Length; i++)
        {
            Debug.Log($"Aktuální checkpoint: {Checkpoint[i]?.name ?? "NULL"}");

            float distance = Vector3.Distance(transform.position, Checkpoint[i].transform.position);

            if (distance < activationDistance)
            {
                Canvas_Checkpoint.SetActive(true);
                DelayAction();
                Canvas_Checkpoint.SetActive(false);
            }
        }*/
    }

    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(5);
    }
}
