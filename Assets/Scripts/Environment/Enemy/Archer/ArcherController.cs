using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherController : MonoBehaviour
{
    float lookRadius = 15;
    NavMeshAgent agent;
    Transform target;
    ArcherAttack archerAttack;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        archerAttack = GetComponent<ArcherAttack>();
    }
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && distance >= archerAttack.DistanseAttackRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }

        if (distance <= lookRadius && distance <= archerAttack.DistanseAttackRadius)
        {
            agent.SetDestination(target.position * -1);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
