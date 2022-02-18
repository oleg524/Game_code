
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class SicretBook : MonoBehaviour, IPointerClickHandler
{
    public float Force = 10;
    bool Cliced;
    Rigidbody rb;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -2 && Cliced == false)
        {
            rb.AddForce(new Vector3(Force, 0, 0), ForceMode.Impulse);
            Cliced = true;
        }

    }   // Вылет книжки


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cliced = false;
    }

}
