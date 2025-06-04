using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EzerealCarController : MonoBehaviour
{
    public enum DriveTypes { FWD, RWD, AWD }
    public DriveTypes driveType;

    [Header("Car Settings")]
    public float horsePower = 1000f;
    public float brakePower = 3000f;
    public float maxForwardSpeed = 150f;
    public float maxSteerAngle = 30f;
    public float steerSpeed = 5f;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    [Header("Wheel Transforms")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    [Header("UI")]
    public Slider accelerationSlider;

    private float currentSpeed;
    private float currentSteerAngle;
    private float speedFactor;
    private float currentAccelerationValue;

    private bool isStarted = true;

    void FixedUpdate()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        Steer();
        Acceleration();
        Brake();
        UpdateWheels();
    }

    void Steer()
    {
        float targetSteerAngle = Input.GetAxis("Horizontal") * maxSteerAngle;
        currentSteerAngle = Mathf.Lerp(currentSteerAngle, targetSteerAngle, steerSpeed * Time.deltaTime);

        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    void Acceleration()
    {
        if (!isStarted)
            return;

        float direction = 0f;

        if (Input.GetKey(KeyCode.W))
            direction = 1f;
        else if (Input.GetKey(KeyCode.S))
            direction = -1f;

        currentAccelerationValue = Mathf.Abs(direction);
        speedFactor = Mathf.InverseLerp(0, maxForwardSpeed, Mathf.Abs(currentSpeed));
        float currentMotorTorque = Mathf.Lerp(horsePower, 0, speedFactor);
        float torque = direction * currentMotorTorque;

        switch (driveType)
        {
            case DriveTypes.RWD:
                rearLeftWheelCollider.motorTorque = torque;
                rearRightWheelCollider.motorTorque = torque;
                break;
            case DriveTypes.FWD:
                frontLeftWheelCollider.motorTorque = torque;
                frontRightWheelCollider.motorTorque = torque;
                break;
            case DriveTypes.AWD:
                frontLeftWheelCollider.motorTorque = torque;
                frontRightWheelCollider.motorTorque = torque;
                rearLeftWheelCollider.motorTorque = torque;
                rearRightWheelCollider.motorTorque = torque;
                break;
        }

        UpdateAccelerationSlider();
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyBrake(brakePower);
        }
        else
        {
            ApplyBrake(0f);
        }
    }

    void ApplyBrake(float brakeForce)
    {
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    void UpdateAccelerationSlider()
    {
        if (accelerationSlider != null)
        {
            accelerationSlider.value = currentAccelerationValue;
        }
    }

    void UpdateWheels()
    {
        UpdateWheelPose(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPose(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPose(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPose(rearRightWheelCollider, rearRightWheelTransform);
    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion quat;
        collider.GetWorldPose(out pos, out quat);
        transform.position = pos;
        transform.rotation = quat;
    }
}
