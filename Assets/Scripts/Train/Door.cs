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
 

    public void OpenDoor()
    {
      
        anim.SetTrigger("open");
        
    }

    public void CloseDoor()
    {
        anim.SetTrigger("close");
    }
}
