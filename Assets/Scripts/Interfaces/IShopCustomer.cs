using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(int itemCode);

    void SellItem(int itemCode);
}
