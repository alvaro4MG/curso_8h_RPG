using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPickup : APickup
{
    [SerializeField] private Quest _quest;

    public override void Pickup(){
        _quest.StartMission();
        Destroy(gameObject, 0.2f);
    }
}
