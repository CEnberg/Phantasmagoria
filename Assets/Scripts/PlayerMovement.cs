using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public Transform orientation;

    [Header("ground Check")]
    public float PlayerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    [Header("Scrap Metal")]
    public int ScrapMetalCount;
    public int MaxScrapCount;
    public int ScrapThreshold;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down,PlayerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
        
        checkScrapMetal();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl() 
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed) 
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void checkScrapMetal()
    {
        if (ScrapMetalCount >= MaxScrapCount)
        {
            print("yay!"); //Do Something
        }
        else if (ScrapMetalCount >= ScrapThreshold * 2)
        {
            print("second tier"); //change into proper parts as needed
        }
        else if (ScrapMetalCount >= ScrapThreshold)
        {
            print("first tier reached!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectible"))
        {
            ScrapMetalCount += 1;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
            print("game over!!! :( ");      // Change as needed
        else if (other.CompareTag("EndOfLevel"))
        {
            print("You did it!!!");
        }
    }
}
