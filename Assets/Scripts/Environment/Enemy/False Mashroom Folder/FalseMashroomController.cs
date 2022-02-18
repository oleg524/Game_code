using UnityEngine;
using UnityEngine.AI;

public class FalseMashroomController : MonoBehaviour
{
    public float lookRadius = 12;
 

    FalseMashroomAnimation FalseMashroomAnimation;
    FalseMashroomAttack falseMashroomAttack;
    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        falseMashroomAttack = GetComponent<FalseMashroomAttack>();
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        FalseMashroomAnimation = GetComponent<FalseMashroomAnimation>();
    }
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && distance >= falseMashroomAttack.DistanseAttackRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }

        if (distance <= lookRadius && distance <= falseMashroomAttack.DistanseAttackRadius)
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
