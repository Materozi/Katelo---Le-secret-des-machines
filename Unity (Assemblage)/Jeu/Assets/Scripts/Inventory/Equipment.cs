using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Equipment : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<Item> OnItemRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }
    private void OnValidate()
    {
        equipmentSlots = equipmentSlotParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem lastItem)
    {
        for(int i =0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].equipmentType == item.equipmentType)
            {
                lastItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        lastItem = null;
        return false;
    }
    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
