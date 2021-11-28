using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI moneyAmtText;

    private void OnEnable()
    {
        PlayerBaseInventory.OnMoneyChanged += UpdateMoneyAmt;
    }

    private void OnDisable()
    {
        PlayerBaseInventory.OnMoneyChanged -= UpdateMoneyAmt;
    }


    void UpdateMoneyAmt(int amt)
    {
        moneyAmtText.text = amt.ToString();
    }
}
