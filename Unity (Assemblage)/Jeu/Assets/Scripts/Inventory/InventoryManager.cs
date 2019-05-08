using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Equipment equipment;

    

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipment.OnItemRightClickedEvent += UnequipFromEquipment;
    }
    private void EquipFromInventory(Item item)
    {
        if(item is EquippableItem)
        {
            
            Equip((EquippableItem)item);
        }
    }
    private void UnequipFromEquipment(Item item)
    {
        if (item is EquippableItem)
        {
            
            Unequip((EquippableItem)item);
        }
    }
    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem lastItem;
            if(equipment.AddItem(item, out lastItem))
            {
                if(lastItem != null)
                {
                    inventory.AddItem(lastItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull() && equipment.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
    public void ToggleInventory()
    {
        if(inventory.gameObject.activeSelf == false)
        {
            inventory.gameObject.SetActive(true);
        }
        else
        {
            inventory.gameObject.SetActive(true);
        }
    }
}
