using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : APickup
{
    [SerializeField] private int _amount;
    [SerializeField] private Item _item;
    [SerializeField] private Inventory _inventory;  //a qué cartera se añadirá

    public override void Pickup(){
        Debug.Log("Picked up: " + _amount + " items " + _item.Name);

        //give to player
        /*if(!_inventory.Wallet.ContainsKey(_item)){        //lógica en Inventory
            _inventory.Wallet.Add(_item, 0);
        }
        _inventory.Wallet[_item] += amount;*/
        _inventory.Add(_item, _amount);

        Destroy(gameObject, 0.2f);
    }
}
