using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;

public class playerDrive : MonoBehaviour
{
    private InputActionMap controls;
    public Transform body;
    public int characterStage;
    public float motorTorque;
    public GameObject stage0;
    public GameObject stage1;
    public GameObject stage2;
    public WheelCollider leftLeg;
    public WheelCollider rightLeg;
    public WheelCollider leftLeg2;
    public WheelCollider rightLeg2;
    public WheelCollider leftLeg3;
    public WheelCollider rightLeg3;
    public WheelCollider middleLeg3;
    // Update is called once per frame
    void Start()
    {
        changeStage(characterStage);
    }

    void Update()
    {
        
    }

    private void driveStage0() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rightLeg.motorTorque = verticalInput * motorTorque;
        leftLeg.motorTorque = verticalInput * motorTorque;
        leftLeg.motorTorque += horizontalInput * motorTorque;
        rightLeg.motorTorque -= horizontalInput * motorTorque;
    }
    private void driveStage1() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rightLeg2.motorTorque = verticalInput * motorTorque;
        leftLeg2.motorTorque = verticalInput * motorTorque;
        leftLeg2.motorTorque += horizontalInput * motorTorque;
        rightLeg2.motorTorque -= horizontalInput * motorTorque;
    }
    private void driveStage2() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rightLeg2.motorTorque = verticalInput * motorTorque;
        leftLeg2.motorTorque = verticalInput * motorTorque;
        leftLeg2.motorTorque += horizontalInput * (motorTorque/4);
        rightLeg2.motorTorque -= horizontalInput * (motorTorque/4);
        middleLeg3.motorTorque = verticalInput * motorTorque;
    }
    private void driveStage3() {
        //todo: implement
    }
    public void changeStage(int stage) {
        body.position = new Vector3(body.position.x, body.position.y + 1, body.position.z);
        switch (stage) {
            case 0:
                stage0.SetActive(true);
                stage1.SetActive(false);
                stage2.SetActive(false);
                characterStage = 0;
                break;
            case 1:
                stage0.SetActive(false);
                stage1.SetActive(true);
                stage2.SetActive(false);
                characterStage = 1;
                break;
            case 2:
                stage0.SetActive(false);
                stage1.SetActive(false);
                stage2.SetActive(true);
                characterStage = 2;
                break;
            default:
                break;
        }
    }
    void FixedUpdate() {
        switch (characterStage) {
            case 0:
                driveStage0();
                break;
            case 1:
                driveStage1();
                break;
            case 2:
                driveStage2();
                break;
            default:
                break;
        }

    }
}