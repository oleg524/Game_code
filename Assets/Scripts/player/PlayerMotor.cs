using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (agent.enabled == true)
        {

             if (target != null)
             {
                agent.SetDestination(target.position);
                FaceTarget();
             }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.speed = 0;
            }

        }
    }
    public void MoveToPoint(Vector3 Point)
    {

        float Distance = Vector3.Distance(transform.position, Point);
        if (Distance >= 0)
            agent.speed = 4;

        agent.SetDestination(Point);
    } // Player Movement
    public void FollowTarget(Interactable NewTarget)
    {
        agent.stoppingDistance = NewTarget.InteractRadius * 0.8f;
        agent.updateRotation = false;

        target = NewTarget.InteractionTransform;
    }
    public void StopFollowTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }
    private void FaceTarget()
    {
        Vector3 directon = (target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(directon.x, 0f, directon.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    } // Look at Object
}

