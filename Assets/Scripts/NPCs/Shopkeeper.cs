using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : InteractableCharacter
{
    private Inventory inventory;

    [Header("References")] 
    [SerializeField] public ShopSellerInventory uiInventory;

    private bool isTalking;
    void Start()
    {
        inventory = new Inventory();
        
        inventory.AddItem(new Item(0,1));
        inventory.AddItem(new Item(1,1));
        inventory.AddItem(new Item(2,1));
        inventory.AddItem(new Item(3,1));
        inventory.AddItem(new Item(4,1));
        inventory.AddItem(new Item(5,1));
        inventory.AddItem(new Item(6,1));
        inventory.AddItem(new Item(7,1));
        
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (other.CompareTag("Player"))
        {
            isTalking = false;
            uiInventory.Hide();
        }
    }

    protected override void DoInteract()
    {
        

        if (!isTalking)
        {
            uiInventory.Show(interactor.GetComponent<IShopCustomer>());
            isTalking = true;
        }
        else
        {
            isTalking = false;
            uiInventory.Hide();
        }
    }
}
