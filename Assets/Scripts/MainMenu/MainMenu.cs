using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _sFXClip;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        //_backgroundMusic = GetComponent<AudioSource>();

        _animator.Play("toggle");
        _backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){

            StartCoroutine(PlayGame());
            //_animator.Play("fundido");

        }else if (Input.GetKeyDown(KeyCode.Q)){
            QuitGame();
        }
    }


    private IEnumerator PlayGame()
    {
        _animator.Play("fundido");
        _sFXClip.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");  // nombre de tu escena de juego
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado"); // visible en el editor
    }

}
