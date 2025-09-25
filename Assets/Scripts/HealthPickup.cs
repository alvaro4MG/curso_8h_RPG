using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : APickup
{
    [SerializeField] private int _healthAmount;

    public override void Pickup(){
        Debug.Log("Healed: " + _healthAmount);
        Destroy(gameObject, 0.2f);
    }
}
