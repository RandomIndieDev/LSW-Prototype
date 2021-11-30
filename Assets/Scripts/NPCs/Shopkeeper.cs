using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : InteractableCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void DoInteract()
    {
        UiManager.Instance.ShowShopWindow();
    }
}
