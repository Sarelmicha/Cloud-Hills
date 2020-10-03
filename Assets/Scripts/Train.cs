using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private float speed =  2f;
    [SerializeField] private float breakSpeed = 0.05f;

    private bool isBreaksOn = false;

    // Update is called once per frame
    void Update()
    {
        if (isBreaksOn)
        {
            Drive(breakSpeed);
        }
        else
        {
            Drive(1f);
        }
       
    }

    private void Drive(float breakSpeed)
    {
        transform.position +=  Vector3.forward  * Time.deltaTime * speed * breakSpeed;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Station")
        {
            isBreaksOn = true;
        }
        else if (other.tag == "Statue")
        {
            speed = 0;
        }
    }

}
