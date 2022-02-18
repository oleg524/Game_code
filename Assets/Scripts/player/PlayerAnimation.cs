using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    #region Singelton
    public static PlayerAnimation instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField] private GameObject playerGraph;
    [SerializeField] private float speedPerecent;
    private int velosity;
    private NavMeshAgent agent;
    private Animator animator;

    #region AnimationConst
    private const string SpeedPerecent = "SpeedPerecent"; 
    private const string Archering = "Archering";
    private const string SwordSlash_1 = "Sword Slash 1";
    private const string SwordSlash_2 = "Sword Slash 2";
    private const string BossGolemSealing = "BossGolemSealingAnimation";
    private const string BossGolemSealingStandUpOnFeet = "BossGolemSealingAnimationStandUpOnFeet"; 
    #endregion


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        velosity = Animator.StringToHash(SpeedPerecent);
    }

    void Update()
    {
        MovementAnimation();
    }
    public void MovementAnimation()
    {
        speedPerecent = agent.speed;
        animator.SetFloat(velosity, speedPerecent);
    }
    public void ShootArrowAnimation()
    {
        animator.SetTrigger(Archering);
    }
    private void SwordSlashAnimationFirstBlade()  
    {
        animator.SetTrigger(SwordSlash_1);
    }
    private void SwordSlashAnimationSecondBlade() 
    {
        animator.SetTrigger(SwordSlash_2);
    }

    public void BossGolemSealingAnimation()
    {
        animator.SetTrigger(BossGolemSealing);
    }
    public void BossGolemSealingAnimationStandUpOnFeet()
    {
        animator.SetTrigger(BossGolemSealingStandUpOnFeet);
    }
}