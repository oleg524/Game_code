using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class FalseMashroomAttack : Combat
{
    public float DistanseAttackRadius;

    [SerializeField] private  GameObject poition;
    private float distance;
    private Transform target;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        myStats = GetComponent<CharacterStats>();
    }

    void FixedUpdate()   
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance <= DistanseAttackRadius)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                if (attackCooldown <= 0f) 
                {
                    Instantiate(poition, transform.position + new Vector3(0, 1, 0), Quaternion.identity); // Poition Spawn

                    Attack(targetStats);
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