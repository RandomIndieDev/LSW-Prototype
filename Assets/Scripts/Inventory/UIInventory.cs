using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory: MonoBehaviour
{
    [Header("References")] 
    [SerializeField] public GameObject uiInventory;
    
    private Inventory inventory;

    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = uiInventory.transform.Find("Item Slot Container");
        itemSlotTemplate = itemSlotContainer.Find("Item Slot Template");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshIventoryItems();
    }

    private void RefreshIventoryItems()
    {
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform =
                Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            
            itemSlotRectTransform.gameObject.SetActive(true);

            Image itemImage = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            itemImage.sprite = item.GetSprite();

            itemSlotRectTransform.SetParent(itemSlotContainer.gameObject.transform);

        }
    }
    
}
