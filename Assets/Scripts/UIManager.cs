using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Animator anim = null;

    [SerializeField] Text numOfPassengersText = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TriggerPlayAnimaton()
    {
        anim.SetTrigger("play");
    }

    public void TriggerPauseAnimaton()
    {
        anim.SetTrigger("pause");
    }

    public void TriggerResumeAnimaton()
    {
        anim.SetTrigger("resume");
    }

    public void SetNumOfPassengers(int numOfPassengers)
    {
        numOfPassengersText.text = "Passengers in train: " + numOfPassengers;
    }
}
