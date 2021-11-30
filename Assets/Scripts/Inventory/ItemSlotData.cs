using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotData : MonoBehaviour
{
    public ItemAttributes itemAttributes;

    public void SetItemData(ItemAttributes item)
    {
        this.itemAttributes = item;
    }

    public ItemAttributes GetItemData()
    {
        return itemAttributes;
    }
}
