using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Slot[] slotList;

    public virtual void Start()
    {
        slotList = GetComponentsInChildren<Slot>();
    }

    public bool StoreItem(int id)
    {
        Item item = InventoryManager.Instance.GetItemByID(id);
        return StoreItem(item);
    }
    
    public bool StoreItem(Item item)
    {
        if (item==null)
        {
            Debug.LogWarning("Not Exist ID");
            return false;
        }

        if (item.Capacity == 1)
        {
            Slot slot = FindEmptySlot();
            if (slot == null)
            {
                Debug.LogWarning("No Empty Slot");
                return false;
            }
            else
            {
                slot.StoreItem(item);
            }
        }
        else
        {
            Slot slot = FindSameIdSlot(item);
            if (slot!=null)
            {
                slot.StoreItem(item);
            }
            else
            {
                Slot emptySlot = FindEmptySlot();
                if (emptySlot != null)
                {
                    emptySlot.StoreItem(item);
                }
                else
                {
                    Debug.LogWarning("No Empty Slot");
                    return false;
                }
            }
        }

        return true;
    }

    private Slot FindEmptySlot()
    {
        foreach (Slot slot in slotList) 
        {
            if (slot.transform.childCount==0)
            {
                return slot;
            }
        }
        return null;
    }

    private Slot FindSameIdSlot(Item item)
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount>=1&&slot.GetItemID()==item.ID&&slot.IsFilled()==false)
            {
                return slot;
            }
        }

        return null;
    }
}

