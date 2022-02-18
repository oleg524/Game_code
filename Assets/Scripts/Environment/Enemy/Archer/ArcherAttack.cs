using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class ArcherAttack : Combat
{
    public float DistanseAttackRadius;
    Transform target;
    float distance;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;
    private ArcherAnimation archerAnimation;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        myStats = GetComponent<CharacterStats>();
        archerAnimation = GetComponent<ArcherAnimation>();
    }

    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        attackCooldown -= Time.deltaTime;

        if (distance <= DistanseAttackRadius)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                if (attackCooldown <= 0f)
                {
                    Vector3 targetDir = target.position + new Vector3(0, 1.5f, 0) - arrowSpawn.transform.position;

                    GameObject launchedArrow = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
                    Rigidbody rb = launchedArrow.GetComponent<Rigidbody>();
                    rb.velocity = targetDir * shootForce;

                    attackCooldown = attackSpeed;

                    archerAnimation.AttackAnimation();
                }
            }
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DistanseAttackRadius);
    }
}
