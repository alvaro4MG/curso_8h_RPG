using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private PlayerController _player;

    private bool _isPaused = false;

    private InputActions _controls;

    private void Awake(){
        _controls = _player.Controls;
    }


    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }*/

    private void OnEnable(){
        //_controls.UI.Enable();
        _controls.Player.Pause.performed += OnPausePerformed;
        _controls.UI.ExitUI.performed += OnExitUIPerformed;
    }

    private void OnDisable(){
        _controls.Player.Pause.performed -= OnPausePerformed;
        _controls.UI.ExitUI.performed -= OnExitUIPerformed;
    }

    private void OnPausePerformed(InputAction.CallbackContext context){
        //Debug.Log("Pausa");
        _controls.UI.Enable();
        if (_isPaused){
            Resume();
        }else{
            Pause();
        }
    }

    private void OnExitUIPerformed(InputAction.CallbackContext context){
        _controls.UI.Disable();
        if (_isPaused){
            Resume();
        }
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //_player.isControllable = true;
        _controls.Player.Enable();
        _isPaused = false;
    }

    public void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //_player.isControllable = false;
        _controls.Player.Disable();
        _isPaused = true;
    }
}
