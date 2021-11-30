using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    
    public int itemCode;
    public int amount;

    public Item(int itemCode, int amount)
    {
        this.itemCode = itemCode;
        this.amount = amount;
    }

    public Sprite GetSprite()
    {
        return ItemAssets.Instance.GetSprite(itemCode);
    }

    public int GetItemPrice()
    {
        return ItemAssets.Instance.GetBuyPrice(itemCode);
    }

    public int GetItemSellPrice()
    {
        return ItemAssets.Instance.GetSellPrice(itemCode);
    }
}
