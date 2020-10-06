using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidEvent OnPlayClicked = null;
    [SerializeField] private VoidEvent OnMenuClicked = null;

    [SerializeField] Camera[] cameras;

    [SerializeField] UIManager uIManager = null;

    private AudioSource audio;

    int currentCameraNumber = 0;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
       
    }

    private void Start()
    {
        audio.Play();
    }


    public void Play()
    {
        StartCoroutine(StartGame());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        uIManager.TriggerPauseAnimaton();
    }

    private IEnumerator StartGame()
    {
       

        uIManager.TriggerPlayAnimaton();

        yield return new WaitForSeconds(2f);

        OnPlayClicked.Raise();
    }

    public void SwitchCamera()
    {
        currentCameraNumber++;
        if (currentCameraNumber == cameras.Length)
        {
            currentCameraNumber = 0;
        }
        EnableCamera();
    }

    public void EnableCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCameraNumber)
            {
                cameras[i].enabled = true;
            }
            else
            {
                cameras[i].enabled = false;
            }
        }
    }

}

