using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearWheelDrive : MonoBehaviour
{
    public float maxAngle = 30;
    public float maxTorque = 300;

    public WheelCollider[] wheelColliderArray;
    public Transform[] wheelMeshArray;

    //Joystick reference
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = maxAngle * joystick.Horizontal;
        float torque = maxTorque * joystick.Vertical;;

        wheelColliderArray[0].steerAngle = angle;
        wheelColliderArray[1].steerAngle = angle;

        wheelColliderArray[2].motorTorque = torque;
        wheelColliderArray[3].motorTorque = torque;

        // Assign the each position and rotation of the wheel collider to the wheel transform
        foreach (WheelCollider wheel in wheelColliderArray)
        {
            // Get the position and rotation of the wheel collider
            Vector3 wheelPosition;
            Quaternion wheelRotation;

            wheel.GetWorldPose(out wheelPosition, out wheelRotation);

            // Get the reference of each wheel model
            Transform wheelModel = wheel.transform.GetChild(0);

            // Assign the position of each wheel collider to the position of wheel model
            wheelModel.position = wheelPosition;
            // Assign the rotation of each wheel collider to the rotation of wheel model
            wheelModel.rotation = wheelRotation;
        }
    }
}
