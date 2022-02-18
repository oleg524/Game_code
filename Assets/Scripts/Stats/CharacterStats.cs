using UnityEngine;

public class CharacterStats : MonoBehaviour 
{
    public int MaxHealth = 100;
    public float CurrentHealth { get; private set; }

    public Stat Damage;
    [Header("Armor from 1% to 100%")]
    public Stat Armor;

    private void OnEnable()  
    { 
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(float damage)
    {
        damage *= (1 - (Armor.GetValue() / 100));
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // Damage never go below zero

        CurrentHealth -= damage;
    }

    public void TakeHealing(float healing)
    {
        CurrentHealth += healing;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;

    }
    

    public void Update()
    {
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
       // Debug.Log(transform.name + " died.");
       // Destroy(gameObject);
    }
}
