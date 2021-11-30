using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 originalRectTransform;

    private bool wasOnInventorySlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        wasOnInventorySlot = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalRectTransform = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalRectTransform = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null)
        {
            ResetPosition();
            return;
        }
        
        var slot = eventData.pointerEnter.GetComponent<ItemSlot>();

        if (slot == null)
        {
            ResetPosition();
            Debug.Log("Tezt");
            return;
        }

        if (slot.isResitricted)
        {
            var itemData = GetComponent<ItemSlotData>().GetItemData();
            wasOnInventorySlot = true;
            
            if (itemData.itemType != slot.allowedItemType)
            {
                ResetPosition();
                return;
            }

            var data = GetComponent<ItemSlotData>();
            data.equiped = true;
            slot.EquipItem(data.GetItemData());
            
        }
        else
        {
            if (wasOnInventorySlot)
            {
                wasOnInventorySlot = false;
                
                var data = GetComponent<ItemSlotData>();
                data.equiped = false;
                FindObjectOfType<PlayerController>().DisableOutfit(data.GetItemData());
            }
        }

        gameObject.transform.SetParent(slot.transform);
            
        rectTransform.anchorMin = slot.baseSlot.anchorMin;
        rectTransform.anchorMax = slot.baseSlot.anchorMax;
        rectTransform.pivot = slot.baseSlot.pivot;
        rectTransform.anchoredPosition = Vector3.zero;
        
        
        

        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    private void ResetPosition()
    {
        rectTransform.anchoredPosition = originalRectTransform;
        canvasGroup.blocksRaycasts = true;
    }
}
