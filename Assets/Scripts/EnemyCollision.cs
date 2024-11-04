using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour 
{

    public Rigidbody rb;

    private void Update() {
        transform.position = rb.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            print("You lose!"); // change as needed
        }
    }
}