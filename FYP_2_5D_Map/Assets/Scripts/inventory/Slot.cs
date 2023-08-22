using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public GameObject itemPrefab;
    public void StoreItem(Item item)
    {
        if (transform.childCount == 0)
        {
            GameObject itemGameObject = Instantiate(itemPrefab) as GameObject;
            itemGameObject.transform.SetParent(this.transform);
            itemGameObject.transform.localScale = Vector3.one;
            itemGameObject.transform.localPosition = Vector3.zero;
            itemGameObject.GetComponent<ItemUI>().SetItem(item);
        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
    }

    public Item.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type;
    }

    public int GetItemID()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }
    public bool IsFilled()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.Capacity;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount>0)
        {
            InventoryManager.Instance.HideToolTip();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount>0)
        {
            string toolTip = transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();
            InventoryManager.Instance.ShowToolTip(toolTip);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (transform.childCount>0)
        {
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
            if (InventoryManager.Instance.IsSelectedItem==false)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    int amountSelected = (currentItem.Amount + 1) / 2;
                    InventoryManager.Instance.SelectedItemUI(currentItem.Item,amountSelected);
                    int amountRemained = currentItem.Amount - amountSelected;
                    if (amountRemained<=0)
                    {
                        Destroy(currentItem.gameObject);
                    }
                    else
                    {
                        currentItem.SetAmount(amountRemained);
                    }
                }
                else
                {
                    InventoryManager.Instance.SelectedItemUI(currentItem.Item,currentItem.Amount);
                    Destroy(currentItem.gameObject);
                }
            }
            else
            {
                if (currentItem.Item.ID==InventoryManager.Instance.SelectedItem.Item.ID)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (currentItem.Item.Capacity>currentItem.Amount)
                        {
                            currentItem.AddAmount();
                            InventoryManager.Instance.RemoveItem();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (currentItem.Item.Capacity>currentItem.Amount)
                        {
                            int amountRemain = currentItem.Item.Capacity = currentItem.Amount;
                            if (amountRemain>=InventoryManager.Instance.SelectedItem.Amount)
                            {
                                currentItem.SetAmount(currentItem.Amount+InventoryManager.Instance.SelectedItem.Amount);
                                InventoryManager.Instance.RemoveItem(InventoryManager.Instance.SelectedItem.Amount);
                            }
                            else
                            {
                                currentItem.SetAmount(currentItem.Amount+amountRemain);
                                InventoryManager.Instance.RemoveItem(amountRemain);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            if (InventoryManager.Instance.IsSelectedItem == true)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    this.StoreItem(InventoryManager.Instance.SelectedItem.Item);
                    InventoryManager.Instance.RemoveItem();
                }
                else
                {
                    for (int i = 0; i < InventoryManager.Instance.SelectedItem.Amount; i++)
                    {
                        this.StoreItem(InventoryManager.Instance.SelectedItem.Item);
                    }
                    InventoryManager.Instance.RemoveItem(InventoryManager.Instance.SelectedItem.Amount);
                }
            }
            else
            {
             return;   
            }
        }
    }
}
