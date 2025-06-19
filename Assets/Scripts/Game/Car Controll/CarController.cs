using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
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


    GameObject Canvas_Fail;
    GameObject Canvas_Success;
    TMP_Text currentSpeedTxt;
    void Start()
    {
        CanvasManager.FailCanvas = this.Canvas_Fail;
        CanvasManager.SuccessCanvas = this.Canvas_Success;
    }

    void Update()
    {
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

        // Moc rychlá jízda byebye
        if (currentSpeed >= 25)
        {
            Canvas_Fail.SetActive(true);
        }

        currentSpeedTxt.text = "Current Speed: " + currentSpeed.ToString("F0");

        if (Canvas_Fail.activeSelf || Canvas_Success.activeSelf)
        {
            currentSpeed = 0;
            maxSpeed = 0;
            currentSpeedTxt.text = "";
        }

    }

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
}
