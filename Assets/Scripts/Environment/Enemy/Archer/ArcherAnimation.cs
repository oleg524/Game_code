using UnityEngine;

public class ArcherAnimation : MonoBehaviour
{
    private const string attack = "Attack";
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void AttackAnimation()
    {
        animator.SetTrigger(attack);
    } 
}
