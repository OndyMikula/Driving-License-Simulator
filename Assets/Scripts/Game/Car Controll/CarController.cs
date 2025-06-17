using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    public float acceleration = 5;
    public float deceleration = 3;
    public float maxSpeed = 10;
    public float turnSpeed = 100;
    public float brakePower = 10;

    private float currentSpeed = 0;
    private float forwardInput = 0;
    private float steerInput = 0;
    private bool isBraking = false;

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

    void Update()
    {
        // AKCELERACE & DOJEZD
        if (forwardInput != 0)
        {
            currentSpeed += forwardInput * acceleration * Time.deltaTime;
        }
        else if (!isBraking)
        {
            // Dojezd (postupné zpomalení)
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        // BRZDA
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
    }
}
