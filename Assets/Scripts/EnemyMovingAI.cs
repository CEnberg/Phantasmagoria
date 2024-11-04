using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyFollowingAI : MonoBehaviour
{   
    public Transform Player;
    public float minDistance;
    public float maxDistance;
    public float MoveSpeed;
    public float inSightAngle;
    public float TurnByAngle;

    public Rigidbody rb;
    public Transform orientation;
    private float originalRotation;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.MoveRotation(orientation.rotation);
        originalRotation = orientation.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetDir = Player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        
        if (math.abs(angle - originalRotation) <= inSightAngle)
        {
            print("In range!");
            transform.LookAt(Player);

            MoveEnemy();
        }
        // else
        //     rb.Sleep();
        // if (Vector3.Distance(transform.position, Player.position) >= minDistance)
        // {
        //     transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        // }
        

        // else 



    }

    void MoveEnemy()
    {
        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance < maxDistance)
            rb.AddForce(transform.forward * MoveSpeed, ForceMode.Force);
    }

}
