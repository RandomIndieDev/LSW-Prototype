using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotData : MonoBehaviour
{
    public ItemAttributes itemAttributes;
    public bool equiped;

    public void SetItemData(ItemAttributes item, bool equiped)
    {
        this.itemAttributes = item;
        this.equiped = equiped;
    }
    

    public ItemAttributes GetItemData()
    {
        return itemAttributes;
    }
}
