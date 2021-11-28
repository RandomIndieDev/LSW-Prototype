using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class BaseInventory : MonoBehaviour
{
    protected int money = 100;
    protected Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
    }

    public abstract void Update();

    public bool DeductMoney(int amt)
    {
        if (money - amt < 0)
            return false;

        money -= amt;

        

        return true;
    }

    public void IncreaseMoney(int amt)
    {
        money += amt;
    }
}
