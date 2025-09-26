using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ANPC))]

public class NPCController : MonoBehaviour
{

    private ANPC _behaviour;

    private SpriteRenderer _renderer;

    private bool _interactuable = false;
    private bool _missionStarted = false;       //Change this depending on other behaviours
    private bool _missionCompleted = false;

    void Awake(){
        _renderer = GetComponent<SpriteRenderer>();
        _behaviour = GetComponent<ANPC>();
    }


    // Update is called once per frame
    void Update()
    {
        if (_interactuable && !_missionStarted && Input.GetKeyDown(KeyCode.Q))
        {
            Interacted();
            _missionStarted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        //if(other.CompareTag("pickup")){     //hacerlo por tags puede complicar el código
        
        if(other.TryGetComponent(out PlayerController player)){        //esto sirve para cuando los objetos tienen un solo comportamiento

            //Debug.Log("Player entered");
            _interactuable = true;

            if(!_missionCompleted){
                if(_missionStarted){
                    _renderer.color = Color.green;
                }else{
                    _renderer.color = Color.yellow;
                }
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D other){
        
        if(other.TryGetComponent(out PlayerController player)){
            _interactuable = false;
            _renderer.color = Color.white;
        }

    }

    /*private void OnTriggerStay2D(Collider2D other){

        if(other.TryGetComponent(out PlayerController player)){

            //cambiar color del NPC, como ponerle un filtro amarillo
            _renderer.color = Color.yellow;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Empieza Quest");
            }
        }
        
    }*/

    private void Interacted(){
        Debug.Log("NPC was interacted");
        _renderer.color = Color.green;
        _behaviour.Interact();
    }


}
