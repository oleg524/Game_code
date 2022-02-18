using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{

    [HideInInspector] public CharacterStats myStats;
    [HideInInspector] public float attackCooldown = 0;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackDelay;

    public static event System.Action OnAttack;


    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats) 
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            if (OnAttack != null)
            {
                OnAttack();
            }
            attackCooldown = attackSpeed;
        }

    }
    private IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.Damage.GetValue());
    }

}   