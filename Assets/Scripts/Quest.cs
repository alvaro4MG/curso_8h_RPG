using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    [Header("References")]
    [SerializeField] private Inventory _inventory;

    [Header("Reward")]
    [SerializeField] private Item _reward;
    [SerializeField] private int _amount;

    [Header("Requirements")]
    [SerializeField] private Item _requiredItem; //si son varios puede ser una List
    [SerializeField] private int _requiredAmount;

    private bool _started;
    //private bool _completed;

    public void StartMission(){
        if(_started){
            return;
        }

        Debug.Log("Mission " + name + " started");
        _inventory.OnModified += OnInventoryUpdated;
        OnInventoryUpdated();       //por si ha cogido las manzanas antes
    }

    private void OnInventoryUpdated(){
        Debug.Log($"Progress {_inventory.GetAmount(_requiredItem)}/{_requiredAmount}");

        if(_inventory.GetAmount(_requiredItem) >= _requiredAmount){

            _inventory.OnModified -= OnInventoryUpdated;
            _inventory.Add(_requiredItem, -_requiredAmount);
            _inventory.Add(_reward, _amount);
        }
    }

}
