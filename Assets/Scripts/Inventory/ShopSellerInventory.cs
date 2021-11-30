using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSellerInventory : UIInventory
{

    [SerializeField] protected GameObject uiWindow;
    private IShopCustomer shopCustomer;
    protected override void RefreshIventoryItems()
    {
        base.RefreshIventoryItems();

        foreach (Transform child in itemSlotContainer.transform)
        {
            var button = child.transform.GetChild(2);
            var text = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            var itemData = child.GetComponent<ItemSlotData>().itemAttributes;
            
            button.GetComponent<Button>().onClick.AddListener(() => SellItem(itemData.itemCode));

            text.text = "" + itemData.itemBuyPrice;
        }
    }

    public void SellItem(int itemCode)
    {
        shopCustomer.BoughtItem(itemCode);
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        uiWindow.SetActive(true);
    }

    public void Hide()
    {
        uiWindow.SetActive(false);
        
    }
}
