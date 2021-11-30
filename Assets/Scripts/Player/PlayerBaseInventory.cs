using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseInventory : BaseInventory
{
    

    public void AddItem(Item item)
    {
        
    }

    public override void Update()
    {
        
    }

    public bool DeductMoney(int amt)
    {
        var success = base.DeductMoney(amt);
        
        UiManager.Instance.UpdateMoneyAmt(amt);

        return success;
    }
    
    public void IncreaseMoney(int amt)
    {
        base.IncreaseMoney(amt);
        
        UiManager.Instance.UpdateMoneyAmt(amt);
    }
}
