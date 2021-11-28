﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseInventory : BaseInventory
{
    
    public delegate void MoneyChanged(int amt);
    public static event MoneyChanged OnMoneyChanged;
    // Start is called before the first frame update


    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DeductMoney(10);
        }
    }

    public bool DeductMoney(int amt)
    {
        var success = base.DeductMoney(amt);
        
        if (OnMoneyChanged != null) OnMoneyChanged(money);

        return success;
    }
    
    public void IncreaseMoney(int amt)
    {
        base.IncreaseMoney(amt);
        if (OnMoneyChanged != null) OnMoneyChanged(money);
    }
}