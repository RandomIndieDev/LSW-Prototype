using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChecker : MonoBehaviour
{

    public PlayerInventory PlayerInventory;

    private void OnEnable()
    {
        PlayerInventory.UpdateInventory();
    }
}
