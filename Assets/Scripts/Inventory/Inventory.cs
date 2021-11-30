using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(int itemCode)
    {
        int count = 0;
        bool found = false;

        foreach (Item item in itemList)
        {
            if (item.itemCode == itemCode)
            {
                found = true;
                break;
            }

            count++;
        }
        
        if (found)
            itemList.RemoveAt(count);
        
        
    }

    public void EquipItem(int itemCode, bool equip)
    {
        foreach (Item item in itemList)
        {
            if (item.itemCode == itemCode)
            {
                item.equiped = equip;
            }
                
        }
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public bool ContainsItem(int itemCode)
    {
        foreach (Item item in itemList)
        {
            if (item.itemCode == itemCode)
                return true;
        }

        return false;
    }
}
