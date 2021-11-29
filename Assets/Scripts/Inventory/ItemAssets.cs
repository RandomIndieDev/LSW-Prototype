using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    
    [SerializeField]
    public List<SingleItem> singleItems;


    private void Awake()
    {
        Instance = this;
    }
    public Sprite GetSprite(int itemCode)
    {
        foreach (SingleItem item in singleItems)
        {
            if (item.itemCode == itemCode)
                return item.itemSprite;
        }

        return null;
    }
    
    
    
}
