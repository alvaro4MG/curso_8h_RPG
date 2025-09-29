using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Transform _destination;
    [SerializeField] private CinemachineVirtualCamera _exteriorCam;
    [SerializeField] private CinemachineVirtualCamera _interiorCam;
    [SerializeField] private Animator _fadeAnimator;
    [SerializeField] private AudioSource _audio;
    

    private void OnTriggerEnter2D(Collider2D other){

        if(other.TryGetComponent(out PlayerController player)){

            _fadeAnimator.Play("fadeBlack");
            _audio.Play();


            //_exteriorCam.Priority = 0;
            //_interiorCam.Priority = 10;

            StartCoroutine(fadeBlack());
            other.transform.position = _destination.position;

            //other.transform.position = _destination.position;

        }
    }

    private IEnumerator fadeBlack(){
        //yield return new WaitForSeconds(0.5f);
        yield return null;
        _exteriorCam.Priority = 0;
        _interiorCam.Priority = 10;
    }

}
