using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        AddItem(new Item(ItemAttributes.ItemType.Accessory, 6,1));
        AddItem(new Item(ItemAttributes.ItemType.Outfit, 5,1));
        AddItem(new Item(ItemAttributes.ItemType.Hair, 0,1));
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
