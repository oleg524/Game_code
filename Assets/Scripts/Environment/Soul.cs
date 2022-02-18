using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public float FlyUpTime;
    public float Speed;

    private float flyUpTime;
    private Transform target;
    private Vector3 SoulOffestDestination = new Vector3(0, 1, 0);

    private void Awake()
    {
        flyUpTime = FlyUpTime;
        target = PlayerManager.instance.player.transform;
    }

    private void Update()
    {
        flyUpTime -= Time.deltaTime;

        if (flyUpTime > 0f)
        {
            transform.Translate(new Vector3(0, 0.7f, 0)*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position + SoulOffestDestination, Speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.TryGetComponent(out PlayerStats playerStats))
        {
            playerStats.SoulCount += 1;
            Destroy(gameObject);
        }
    }
}
