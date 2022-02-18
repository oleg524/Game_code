using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class PlayerAttack : Combat
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawn;
    [SerializeField] private float duration;  
    [SerializeField] private float distanceAttackDelay = 0.2f;
    [SerializeField] private float distanceAttackSpeed = 1; 
    [SerializeField] private int arrowCount = 30;

    private float distanceAttackCooldown = 0;

    private void Update()
    {
        distanceAttackCooldown -= Time.deltaTime;
        attackCooldown -= Time.deltaTime;
    }

    public void Shoot(RaycastHit hit, Ability especialShells)
    {
        if (especialShells == null)
            if (arrowCount > 0)
            {
                StartCoroutine(ShootArrow(hit.point));
                arrowCount -= 1;
            }
        if (especialShells != null)
        {
            especialShells.Shoot(hit);
            especialShells.currentShellsCount -= 1;
        }

    }

    public IEnumerator ShootArrow (Vector3 hit)
    {
        float progress = 0f;
        float expiredSeconds = 0f;
        Vector3 startPosition;

        if (distanceAttackCooldown <= 0)
        {
            GetComponent<PlayerAnimation>().ShootArrowAnimation();  // trigger Shoot animation
            GetComponent<NavMeshAgent>().speed = 0;

            distanceAttackCooldown = distanceAttackSpeed;

            yield return new WaitForSeconds(distanceAttackDelay);

            Vector3 targetDir = hit - arrowSpawn.position;
            GameObject launchedArrow = Instantiate(arrowPrefab,arrowSpawn.position,Quaternion.LookRotation(targetDir)*Quaternion.Euler(0,90,0));

            startPosition = launchedArrow.transform.position;
            while(progress < 1)
            {
                expiredSeconds += 1;
                progress = expiredSeconds / duration;

                launchedArrow.transform.position = Vector3.Lerp(startPosition, hit, progress);

                yield return null;
            }
            //Rigidbody rb = launchedArrow.GetComponent<Rigidbody>();
            //rb.AddForce(targetDir * shootForce, ForceMode.Impulse);
        }
    }

}