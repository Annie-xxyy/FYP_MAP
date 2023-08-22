using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Item Item { get; set; }
    public int Amount { get; set; }

    private Image itemImage;
    private TMP_Text amountText;

    private Image ItemImage
    {
        get
        {
            if (itemImage==null)
            {
                itemImage = GetComponent<Image>();
            }

            return itemImage;
        }
    }

    private TMP_Text AmountText
    {
        get
        {
            if (amountText == null)
            {
                amountText = GetComponentInChildren<TMP_Text>();
            }

            return amountText;
        }
        
    }

    public void SetItem(Item item, int amount = 1)
    {
        this.Item = item;
        this.Amount = amount;
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        if (Item.Capacity>1)
        {
            AmountText.text = Amount.ToString();
        }
        else
        {
            AmountText.text = "";
        }
        
    }

    

    public void AddAmount(int amount = 1)
    {
        this.Amount += amount;
        if (Item.Capacity>1)
        {
            AmountText.text = Amount.ToString();
        }
        else
        {
            AmountText.text = "";
        }
    }

    public void SetAmount(int amount)
    {
        this.Amount = amount;
        if (Item.Capacity>1)
        {
            AmountText.text = Amount.ToString();
        }
        else
        {
            AmountText.text = "";
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }
}
