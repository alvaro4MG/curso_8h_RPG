using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Dictionary<Item, int> Wallet = new Dictionary<Item, int>();  //los diccionarios no se serializan en Unity, no salen en el inspector

    public event Action OnModified = () => { };

    public void Clear(){
        Wallet.Clear();
        //OnModified = () => { };
    }

    public int GetAmount(Item item){
        if(Wallet.TryGetValue(item, out int amount)){
            return amount;
        }

        return 0;
    }
    

    public void Add(Item item, int amount){
        if(!Wallet.ContainsKey(item)){        //lógica en Inventory
            Wallet.Add(item, 0);
        }
        Wallet[item] += amount;
        OnModified();
    }

}
