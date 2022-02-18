using UnityEngine;

public abstract class Ability : ScriptableObject
{

    // Gameplay parameters
    public bool IsFinished { get; protected set; }
    public float Cooldown;
    public int currentShellsCount;
    [HideInInspector] public AbilityHolder AbilityHolder;

    public virtual void Init() { }

    public abstract void Run();

    public virtual void Shoot(RaycastHit hit) { }
}


 