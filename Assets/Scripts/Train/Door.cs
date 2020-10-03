using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {
            anim.SetTrigger("open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Person")
        {
            anim.SetTrigger("close");
        }
    }
}
