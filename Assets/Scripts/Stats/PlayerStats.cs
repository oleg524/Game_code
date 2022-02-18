using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    #region Singelton
    public static PlayerStats instanse;

    private void Awake()
    {
        instanse = this;
    }
    #endregion

    public int SoulCount = 0;
    public int SoulCountMax = 50; 

    void Start()
    {
        EquipmentManager.instanse.onEquipmentChaned += OnEquipmentChaned;
    }

    void OnEquipmentChaned(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            Armor.AddModifer(newItem.ArmorModifier);
            Damage.AddModifer(newItem.DamageModifier);
        }

        if (oldItem != null)
        {
            Armor.RemoveModifier(oldItem.ArmorModifier);
            Damage.RemoveModifier(oldItem.DamageModifier); 
        }
    }

    public override void Die()
    {
        base.Die();
        //PlayerManager.instance.KillPlayer();
    }
}
