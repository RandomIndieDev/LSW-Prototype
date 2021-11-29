using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI moneyAmtText;
    public GameObject playerInventory;

    private bool isInventoryOpen;

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

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            isInventoryOpen = !isInventoryOpen;
            
            playerInventory.SetActive(isInventoryOpen);
        }
    }
}
