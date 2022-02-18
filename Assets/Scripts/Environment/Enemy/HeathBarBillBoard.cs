using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBarBillBoard : MonoBehaviour
{
    public Transform cam;


    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(cam.position);
    }

}
