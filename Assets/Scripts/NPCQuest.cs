using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : ANPC
{
    [SerializeField] private Quest _quest;

    public override void Interact(){
        Debug.Log("Quest from NPC started");

        _quest.StartMission();
        //Destroy(gameObject, 0.2f);
    }
}
