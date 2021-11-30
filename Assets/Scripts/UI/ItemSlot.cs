using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IBeginDragHandler
{
    public RectTransform baseSlot;

    public bool isResitricted;
    public bool equipPlacedItem;

    public ItemAttributes.ItemType allowedItemType;

    public void EquipItem(ItemAttributes itemAttributes)
    {
        if (!equipPlacedItem)
            return;

        FindObjectOfType<PlayerController>().ChangeOutfit(itemAttributes);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("TEST");
        
    }
}
