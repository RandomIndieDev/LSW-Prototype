using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Clothes,
        Accessories,
        Hair,
        None
    }

    public ItemType itemType;
    public int itemCode;
    public int amount;

    public Item(ItemType itemType, int itemCode, int amount)
    {
        this.itemType = itemType;
        this.itemCode = itemCode;
        this.amount = amount;
    }

    public Sprite GetSprite()
    {
        return ItemAssets.Instance.GetSprite(itemCode);
    }
}
