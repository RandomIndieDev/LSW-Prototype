using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UiManager : MonoBehaviour
{
    
    public static UiManager Instance { get; private set; }

    [Header("References")]
    public TextMeshProUGUI moneyAmtText;
    public GameObject dialogBox;
    
    public GameObject playerInventory;
    public GameObject shopInventory;
    public GameObject tutorialScreen;

    private bool isInventoryOpen;
    private bool isShopOpen;

    private void Awake()
    {
        Instance = this;

        isShopOpen = false;
        isInventoryOpen = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            isInventoryOpen = !isInventoryOpen;
            
            playerInventory.SetActive(isInventoryOpen);
        }
    }


    public void UpdateMoneyAmt(int amt)
    {
        moneyAmtText.text = amt.ToString();
    }

    public void ShowShopWindow()
    {
        if (isInventoryOpen || isShopOpen)
            return;
        
        shopInventory.SetActive(true);
    }

    public void CloseShopWindow()
    {
        shopInventory.SetActive(false);
    }

    public void ClosePlayerInventory()
    {
        isInventoryOpen = false;
        playerInventory.SetActive(false);
    }

    public void CloseTutorialScreen()
    {
        tutorialScreen.SetActive(false);
    }

    public void SetupDialogBox(string name, string[] lines)
    {
        dialogBox.SetActive(true);
        GameManager.Instance.AllowPlayerMove(false);
        dialogBox.GetComponent<Dialog>().StartDialog(name, lines);
        
    }


}
