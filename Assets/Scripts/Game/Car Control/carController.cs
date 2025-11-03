using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class carController : MonoBehaviour
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
    //           po narazu do baraku bude prehranej zvuk BYEBYE

    // Start is called before the first frame update
    #region Variables
    public gameController gameC;

    public float acceleration;
    public float deceleration;
    public float maxSpeed;
    public float turnSpeed;
    public float brakePower;
    public float currentSpeed;

    float forwardInput = 0;
    float steerInput = 0;
    bool isBraking = false;

    public TMP_Text currentSpeedTxt;

    Rigidbody rb;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentSpeedTxt.text = "Current Speed: " + currentSpeed.ToString("F0");

        if (gameC.Canvas_Fail.activeSelf)
        {
            currentSpeed = 0;
            maxSpeed = 0;
            currentSpeedTxt.text = "";
        }

        if (transform.position.y < -20) //spadnul z mapy
        {
            transform.position = new Vector3(32, (float)0.12, 37);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gameC.Canvas_Fail.SetActive(true);
            currentSpeed = 0;
            maxSpeed = 0;
            currentSpeedTxt.text = "";
        }

    }

    void FixedUpdate()
    {
        #region CarMovement
        // Zrychleni
        if (forwardInput != 0)
        {
            currentSpeed += forwardInput * acceleration * 2.2f * Time.fixedDeltaTime;
        }
        /*else if (currentSpeed > 4)  //priprava na razeni
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        }*/


        else if (!isBraking)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        }

        if (isBraking)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakePower * Time.fixedDeltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Fyzikální pohyb a rotace
        Vector3 move = transform.forward * (currentSpeed * 0.3f) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        if (currentSpeed > 0.5f) //zataceni
        {
            Quaternion deltaRot = Quaternion.Euler(Vector3.up * steerInput * turnSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRot);
        }
        else if (currentSpeed < -0.5f) //couvani pri couvani
        {
            Quaternion deltaRot = Quaternion.Euler(Vector3.up * -steerInput * turnSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRot);
        }
        #endregion
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