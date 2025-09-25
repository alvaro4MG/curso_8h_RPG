using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]     //inyección de dependencia
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    public enum EState{
        Idle,
        Left,
        Right,
        Up,
        Down
    }

    [SerializeField] private float _speed;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameObject _inventoryPanel;


    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _input;
    private EState _state = EState.Idle;

    // Awake se llama cuando se instancia el objeto
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   //coger referencias es mejor en el Awake, inicializaciones en el Start
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start(){
        _inventory.Clear();
        Idle();
    }

    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = _inventoryPanel.activeSelf;
            _inventoryPanel.SetActive(!isActive);  // alterna visible/invisible
        }

        
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;    //con esto se puede mover en diagonal
        if(_input.x != 0 && _input.y != 0 ){            //de esta forma bloqueamos el movimiento en diagonal, solo para los lados
            _input.y = 0;
        }

        //_rigidbody.MovePosition(_input * Time.deltaTime * _speed);     //distintas formas de mover al personaje (aunque el MovePosition no funciona así)
        //transform.Translate(_input * Time.deltaTime * _speed);
        //_rigidbody.velocity = _input * Time.deltaTime * _speed;
        _rigidbody.velocity = _input * _speed;

        UpdateAnimator();

    }

    void UpdateAnimator(){
        /*if(_input.sqrMagnitude == 0){     //Para cuando no detecte movimiento, aunque mejor ponerlo al final
            Idle();
            return;
        }*/
        if(_input.x > 0){
            MoveRight();
            return;
        }else if(_input.x < 0){
            MoveLeft();
            return;
        }

        if(_input.y > 0){
            MoveUp();
            return;
        }else if(_input.y < 0){
            MoveDown();
            return;
        }

        Idle();
    }

    private void OnTriggerEnter2D(Collider2D other){
        //if(other.CompareTag("pickup")){     //hacerlo por tags puede complicar el código
        
        /*if(other.TryGetComponent(out APickup pickup)){        //esto sirve para cuando los objetos tienen un solo comportamiento
            pickup.Pickup();
        }*/

        var pickups = other.GetComponents<APickup>();
        for(var i = 0; i < pickups.Length; i++){
            pickups[i].Pickup();
        }
    }

    void MoveRight(){
        if(_state == EState.Right){     //Esto se podría hacer con switches, diccionarios, etc. Mejor que esto
            return;
        }

        _animator.Play("MoveRight");
        _state = EState.Right;
    }

    void MoveLeft(){
        if(_state == EState.Left){
            return;
        }

        _animator.Play("MoveLeft");
        _state = EState.Left;
    }

    void MoveUp(){
        if(_state == EState.Up){
            return;
        }

        _animator.Play("MoveUp");
        _state = EState.Up;
    }

    void MoveDown(){
        if(_state == EState.Down){
            return;
        }

        _animator.Play("MoveDown");
        _state = EState.Down;
    }

    void Idle(){
        if(_state == EState.Idle){
            return;
        }

        _animator.Play("idle");
        _state = EState.Idle;
    }


}
