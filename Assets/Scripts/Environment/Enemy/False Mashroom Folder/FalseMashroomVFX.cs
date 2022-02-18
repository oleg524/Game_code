using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FalseMashroomVFX : MonoBehaviour
{
    public VisualEffect VFX;

    private void Awake()
    {
        StartCoroutine(BreakingPoition());
    }


    IEnumerator BreakingPoition()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
