using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : UIInventory
{
    [SerializeField] protected Transform SellingInventoryContainer;
    [SerializeField] protected Transform SellingInventoryTemplate;

    [SerializeField] protected PlayerController shopCustomer;
    

    public override void AddItem(Item item)
    {
        base.AddItem(item);
        
        RectTransform itemSlotRectTransform =
            Instantiate(SellingInventoryTemplate, SellingInventoryContainer).GetComponent<RectTransform>();
                
        itemSlotRectTransform.gameObject.SetActive(true);
        
        var button = itemSlotRectTransform.transform.GetChild(2);
        var text = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        button.GetComponent<Button>().onClick.AddListener(() => SellItem(item.itemCode));

        text.text = "" + item.GetItemSellPrice();
            
        itemSlotRectTransform.GetComponent<ItemSlotData>().SetItemData(ItemAssets.Instance.GetItemData(item.itemCode), item.equiped);

        Image itemImage = itemSlotRectTransform.Find("Image").GetComponent<Image>();
        itemImage.sprite = item.GetSprite();

        itemSlotRectTransform.SetParent(SellingInventoryContainer.gameObject.transform);
    }

    private void ClearInventories()
    {
        
        for (int i = 1; i < itemSlotContainer.childCount; i++)
        {
            Destroy(SellingInventoryContainer.GetChild(i).gameObject);
            Destroy(itemSlotContainer.GetChild(i).gameObject);
        }
    }

    public void RemoveItem(Inventory inventory)
    {
        ClearInventories();
        
        SetInventory(inventory);
    }

    public void SellItem(int itemCode)
    {
        shopCustomer.SellItem(itemCode);
    }
}
