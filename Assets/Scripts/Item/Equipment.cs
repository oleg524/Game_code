using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    public EquipmentSlot EquipSlot;

    public SkinnedMeshRenderer Mesh;

    public int ArmorModifier;
    public int DamageModifier;

    public bool IsArtifact = false;

    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(IsArtifact))]
    public Ability Ability;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instanse.Equip(this);
        RemoveFromInventory();
    }
}
public enum EquipmentSlot { Armor, MeleeWeapon, DistanceWeapon, Artifact1, Artifact2, Artifact3 } 
