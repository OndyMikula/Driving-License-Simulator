using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class CarController : MonoBehaviour
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

    // Start is called before the first frame update
    public float acceleration = 5;
    public float deceleration = 3;
    public float maxSpeed = 30;
    public float turnSpeed = 100;
    public float brakePower = 10;
    public float currentSpeed = 0;
    
    float forwardInput = 0;
    float steerInput = 0;
    bool isBraking = false;

    GameObject player;
    [SerializeField] GameObject[] DrivingLine;

    public GameObject Canvas_Fail;
    public GameObject Canvas_Success;
    public GameObject Canvas_Checkpoint;

    public TMP_Text currentSpeedTxt;
    public TMP_Text scoretxt;
    int score = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Canvas_Fail = GameObject.Find("Canvas_Fail");
        Canvas_Success = GameObject.Find("Canvas_Success");
        Canvas_Checkpoint = GameObject.Find("Canvas_Checkpointy");

        Canvas_Checkpoint.SetActive(false);
        Canvas_Fail.SetActive(false);
        Canvas_Success.SetActive(false);
    }

    void Update()
    {
        foreach (var line in DrivingLine)
        {
            var collider = line.GetComponent<BoxCollider>();

            Bounds bounds = new Bounds(collider.bounds.center, collider.bounds.size + Vector3.one * 0.1f);

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

        #region InputSystem
        // Zrychleni
        if (forwardInput != 0)
        {
            currentSpeed += forwardInput * acceleration * Time.deltaTime;
        }
        else if (!isBraking)
        {
            // Dojezd
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        // Brzda
        if (isBraking)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakePower * Time.deltaTime);
        }

        // Limit rychlosti
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Pohyb
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Otáčení
        if (currentSpeed > 1.5)
        {
            transform.Rotate(Vector3.up, steerInput * turnSpeed * Time.deltaTime);
        }
        #endregion

        // Moc rychlá jízda byebye
        if (currentSpeed >= 25)
        {
            Canvas_Fail.SetActive(true);
        }

        currentSpeedTxt.text = "Current Speed: " + currentSpeed.ToString("F0");

        if (Canvas_Fail.activeSelf)
        {
            currentSpeed = 0;
            maxSpeed = 0;
            currentSpeedTxt.text = "";
        }

    }
    #region InputSystem
    public void OnForward(InputAction.CallbackContext context)
    {
        if (context.performed)
            forwardInput = 1;
        else if (context.canceled)
            forwardInput = 0;
    }

    public void OnBackward(InputAction.CallbackContext context)
    {
        if (context.performed)
            forwardInput = -1;
        else if (context.canceled)
            forwardInput = 0;
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        steerInput = context.ReadValue<float>();
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        isBraking = context.ReadValueAsButton();
    }
    #endregion
}
