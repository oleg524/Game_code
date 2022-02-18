using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public Ability Ability_1;
    public Ability Ability_2;
    public Ability Ability_3;

    [SerializeField] private Image AbilityButton_1;
    [SerializeField] private Image AbilityButton_2;
    [SerializeField] private Image AbilityButton_3;  

    public Animator Animator;
    public Ability CurrentAbility;
    private Inventory inventory;
    private void Start()
    {
        EquipmentManager equipmentManager = EquipmentManager.instanse;
        equipmentManager.onEquipmentChaned += setAbility;

        inventory = Inventory.instance;
    }

    private void setAbility(Equipment newAbility, Equipment oldAbility)
    {
        if (newAbility.EquipSlot == EquipmentSlot.Artifact1)
        {
            if (Ability_1 == null)
            {
                Ability_1 = newAbility.Ability;
                AbilityButton_1.sprite = newAbility.icon;
            }
            else if (Ability_2 == null)
            {
                Ability_2 = newAbility.Ability;
                AbilityButton_2.sprite = newAbility.icon;
            }
            else if (Ability_3 == null)
            {
                Ability_3 = newAbility.Ability;
                AbilityButton_3.sprite = newAbility.icon;
            }
        }
    }


    private void Update()
    {
        if (CurrentAbility != null && !CurrentAbility.IsFinished)
        {
            CurrentAbility.Run();
        }
        else
        {
            if (Ability_1 != null && Input.GetKeyDown(KeyCode.Q))
                UsingAbility(Ability_1);

            if (Ability_2 != null && Input.GetKeyDown(KeyCode.W))
                UsingAbility(Ability_2);

            if (Ability_3 != null && Input.GetKeyDown(KeyCode.E))
                UsingAbility(Ability_3);
        }
        abilityCooldowns();
    }

    private void abilityCooldowns()
    {
        if (Ability_1 != null && Ability_1.Cooldown > 0)
            Ability_1.Cooldown -= Time.deltaTime;

        if (Ability_2 != null && Ability_2.Cooldown > 0)
            Ability_2.Cooldown -= Time.deltaTime;

        if (Ability_3 != null && Ability_3.Cooldown > 0)
            Ability_3.Cooldown -= Time.deltaTime;
    }

    public void UsingAbility(Ability ability)
    {
        CurrentAbility = Instantiate(ability);
        CurrentAbility.AbilityHolder = this;
        CurrentAbility.Init(); 
    }

}
