using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow : MonoBehaviour
{
    public Transform PlayerTransform;
    public float SmoothSpeed = 0.1f;
    public Vector3 Offset;

    void Start()
    {
       // StartRotationCamera();
    }
    void Update()
    {
        Vector3 desiredPosition = PlayerTransform.position + Offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = SmoothPosition;
        
    }

    void StartRotationCamera()
    {
        Vector3 RelativePos = PlayerTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(RelativePos);


    } // Слижение за объектом. 
}
