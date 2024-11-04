using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform cameraRotation;

    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraRotation.rotation;
    }
}

