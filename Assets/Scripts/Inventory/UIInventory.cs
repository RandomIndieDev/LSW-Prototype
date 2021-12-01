using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIInventory: MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Transform itemSlotContainer;
    [SerializeField] protected Transform itemSlotTemplate;

    protected Inventory inventory;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        
        RefreshIventoryItems();
    }

    protected virtual void RefreshIventoryItems()
    {
        foreach (Item item in inventory.GetItemList())
        {
            if (item.equiped)
                continue;
            
            AddItem(item);
        }
    }

    public virtual void AddItem(Item item)
    {
        RectTransform itemSlotRectTransform =
            Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                
        itemSlotRectTransform.gameObject.SetActive(true);
            
        itemSlotRectTransform.GetComponent<ItemSlotData>().SetItemData(ItemAssets.Instance.GetItemData(item.itemCode), item.equiped);

        Image itemImage = itemSlotRectTransform.Find("Image").GetComponent<Image>();
        itemImage.sprite = item.GetSprite();

        itemSlotRectTransform.SetParent(itemSlotContainer.gameObject.transform);
    }
    
}
