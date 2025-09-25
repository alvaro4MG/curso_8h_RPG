using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : APickup
{
    [SerializeField] private int _manaAmount;

    public override void Pickup(){
        Debug.Log("Restored mana: " + _manaAmount);
        Destroy(gameObject, 0.2f);
    }
}
