using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemUI : MonoBehaviour
{
    public Item Item { get; private set; }
    public int Amount { get; private set; }

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

    private float targetScale = 1f;
    private Vector3 animationScale = new Vector3(1.4f,1.4f,1.4f);
    private float smoothing = 4;

    private void Update()
    {
        if (transform.localScale.x!=targetScale)
        {
            float scale = Mathf.Lerp(transform.localScale.x, targetScale, smoothing*Time.deltaTime);
            transform.localScale = new Vector3(scale, scale, scale);
            if (Mathf.Abs(transform.localScale.x-targetScale)<.02f)
            {
                transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            }
        }
    }

    public void SetItem(Item item, int amount = 1)
    {
        transform.localScale = animationScale;
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
        transform.localScale = animationScale;
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

    public void ReduceAmount(int amount =1)
    {
        transform.localScale = animationScale;
        this.Amount -= amount;
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
        transform.localScale = animationScale;
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
