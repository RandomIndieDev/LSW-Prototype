using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    
    [SerializeField]
    public List<ItemAttributes> singleItems;


    private void Awake()
    {
        Instance = this;
    }
    public Sprite GetSprite(int itemCode)
    {
        foreach (ItemAttributes item in singleItems)
        {
            if (item.itemCode == itemCode)
                return item.itemSprite;
        }

        return null;
    }

    public int GetSellPrice(int itemCode)
    {
        foreach (ItemAttributes item in singleItems)
        {
            if (item.itemCode == itemCode)
                return item.itemSellPrice;
        }

        return 0;
    }

    public int GetBuyPrice(int itemCode)
    {
        foreach (ItemAttributes item in singleItems)
        {
            if (item.itemCode == itemCode)
                return item.itemBuyPrice;
        }

        return 0;
    }

    public ItemAttributes GetItemData(int itemCode)
    {
        foreach (ItemAttributes item in singleItems)
        {
            if (item.itemCode == itemCode)
                return item;
        }

        return null;
    }
    
    
    
}
