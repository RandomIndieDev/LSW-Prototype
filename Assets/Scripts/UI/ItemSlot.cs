using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public RectTransform baseSlot;

    public bool isResitricted;

    public Item.ItemType allowedItemType;

    public void OnDrop(PointerEventData eventData)
    {
        bool allowDrop = true;

        if (isResitricted)
        {
            if (eventData.pointerDrag.GetComponent<Item>().itemType != allowedItemType)
                allowDrop = false;
        }
        
        if (!allowDrop)
            return;
        
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.gameObject.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                baseSlot.anchoredPosition;
        }
    }
}
