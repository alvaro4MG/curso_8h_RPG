using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    //[SerializeField] private GameObject _pauseBox;
    [SerializeField] private PlayerController _player;

    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _player.isControllable = true;
        _isPaused = false;
    }

    public void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _player.isControllable = false;
        _isPaused = true;
    }
}
