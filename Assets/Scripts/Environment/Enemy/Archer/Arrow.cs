using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class Arrow : Combat
{
    private float lifeTimer = 10f;
    private float timer;
    bool hitSomething = false;
    Transform target;
    CharacterStats targetStats;
    Rigidbody rb;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        transform.rotation = Quaternion.LookRotation(target.position - transform.position) * Quaternion.Euler(0,90,0);
        timer = lifeTimer;
        myStats = GetComponent<CharacterStats>();
        targetStats = target.GetComponent<CharacterStats>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            StartCoroutine(DestroyFunction());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && hitSomething == false)
        {
            Attack(targetStats);
            StartCoroutine(DestroyFunction());
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Untagged" && hitSomething == false)
        {
            hitSomething = true;
            Stick();
        }
    }
    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private IEnumerator DestroyFunction()
    {
        yield return null;
        Destroy(gameObject);
    }
}