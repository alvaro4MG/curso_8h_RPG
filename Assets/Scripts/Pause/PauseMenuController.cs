using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private RectTransform _pointer;
    [SerializeField] private RectTransform[] _options;
    [SerializeField] private float _paddingPointer = -30f;
    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.yellow;
    [SerializeField] private float _inputDelay = 0.25f;

    [Header("References")]
    [SerializeField] private PauseManager _pauseManager;
    [SerializeField] private PlayerController _player;

    private InputActions _controls;
    private int pointerIndex = 0;

    private float _nextInputTime = 0f;


    private void Awake(){
        _controls = _player.Controls;
    }

    private void OnEnable(){
        _controls.UI.AcceptUI.performed += OnAcceptUIPerformed;
        //_controls.UI.CancelUI.performed += OnCancelUIPerformed;
    }

    private void OnDisable(){
        _controls.UI.AcceptUI.performed -= OnAcceptUIPerformed;
        //_controls.UI.CancelUI.performed -= OnCancelUIPerformed;
    }

    private void OnAcceptUIPerformed(InputAction.CallbackContext context){
        switch(pointerIndex){
            case 0:
                    Resume();
                break;
            case 1:
                    Settings();
                break;
            case 2:
                    Quit();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        
        //Vector2 nav = _controls.UI.MoveUI.ReadValue<Vector2>();
        //float vert = nav.y;
        if(_controls != null && _controls.UI.enabled){
            float vert = _controls.UI.MoveUI.ReadValue<float>();

            if(Time.time >= _nextInputTime){

                if(vert > 0.5f){
                    pointerIndex = (pointerIndex - 1 + _options.Length) % _options.Length;
                    _nextInputTime = Time.time + _inputDelay;
                    UpdatePointer();
                    Debug.Log("Llama");
                }else if(vert < -0.5f){
                    pointerIndex = (pointerIndex + 1) % _options.Length;
                    _nextInputTime = Time.time + _inputDelay;
                    UpdatePointer();
                }
                
                
            }
        }

    }

    private void UpdatePointer(){

        RectTransform target = _options[pointerIndex];
        Vector2 pointerPos = new Vector2(target.anchoredPosition.x + _paddingPointer, target.anchoredPosition.y);
        _pointer.anchoredPosition = pointerPos;

    }

    private void Resume(){
        //var pm = FindObjectOfType<PauseManager>();
        if(_pauseManager != null){
            _pauseManager.Resume();
        }
    }

    private void Settings(){
        Debug.Log("Entered settings");
    }

    private void Quit(){
        Application.Quit();
        Debug.Log("Juego cerrado"); // visible en el editor
    }


}
