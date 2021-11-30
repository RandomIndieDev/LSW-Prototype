using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemAttributes
{
    public enum ItemType
    {
        Outfit,
        Accessory,
        Hair,
        None
    }
    
    public int itemCode;
    public ItemType itemType;
    public Sprite itemSprite;
    public int itemBuyPrice;
    public int itemSellPrice;
    public String animatorName;

}
