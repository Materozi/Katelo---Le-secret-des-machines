using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image Image;
    public event Action<Item> OnRightClickEvent;
    private Item _item;
    public Item Item {
        get { return _item; }
        set {
            _item = value;
            if(_item == null)
            {
                Image.enabled = false;
            }
            else
            {
                Image.sprite = _item.Icon;
                Image.enabled = true;
            }
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            
            if(Item != null && OnRightClickEvent != null)
            {
                
                OnRightClickEvent(Item);
            }
        }
    }
    protected virtual void OnValidate()
    {
        if(Image == null)
        {
            Image = GetComponent<Image>();
        }
    }
}
