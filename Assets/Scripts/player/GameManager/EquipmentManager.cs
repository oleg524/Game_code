using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singelton
    public static EquipmentManager instanse;

    private void Awake()
    {
        instanse = this;
    }
    #endregion

    Inventory inventory; 
    public Equipment[] CurrentEquipment;
    public SkinnedMeshRenderer TargetMesh;
    private SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChaned(Equipment newItem, Equipment oldItem);
    public OnEquipmentChaned onEquipmentChaned;

    private void Start()
    {
        inventory = Inventory.instance; 

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        CurrentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.EquipSlot;

        Equipment oldItem = null;

        if (CurrentEquipment[slotIndex] != null)
        {
            oldItem = CurrentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChaned != null)
        {
            onEquipmentChaned.Invoke(newItem, oldItem);
        }


        CurrentEquipment[slotIndex] = newItem;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.Mesh);
        newMesh.transform.parent = TargetMesh.transform;
        newMesh.bones = TargetMesh.bones;
        newMesh.rootBone = TargetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public void Unequip(int slotIndex)
    {
        if(CurrentEquipment[slotIndex] != null)
        {
            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject); 
            }

            Equipment oldItem = CurrentEquipment[slotIndex];
            inventory.Add(oldItem);

            CurrentEquipment[slotIndex] = null;

            if (onEquipmentChaned != null)
            {
                onEquipmentChaned.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < CurrentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
