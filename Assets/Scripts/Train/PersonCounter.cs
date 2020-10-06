using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCounter : MonoBehaviour
{
    [SerializeField] private Train train = null;
    [SerializeField] private IntEvent onNumOfPassengersUpdated = null;

    private int maxNumOfPassengersInTrain = 0;
    private int currentNumOfPassengersInTrain = 0;

    private void Awake()
    {
        onNumOfPassengersUpdated.Raise(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {
          
            Person passegner = other.GetComponent<Person>();

            if (passegner.InTrain())
            {
                HandlePassengerExitTrain(passegner);
            }

            else
            {
                HandlePassengerEnterTrain(other, passegner);
            }
        }
    }

    private void HandlePassengerEnterTrain(Collider other, Person passegner)
    {
        passegner.InTrain(true);

        currentNumOfPassengersInTrain++;

        onNumOfPassengersUpdated.Raise(currentNumOfPassengersInTrain);



        other.gameObject.SetActive(false);


        print("currentNumOfPassengers = " + currentNumOfPassengersInTrain);
        print("maxNumOfPassengers = " + maxNumOfPassengersInTrain);

        if (currentNumOfPassengersInTrain == maxNumOfPassengersInTrain)
        {
            print("lets drive.");
            train.CloseDoors();

            //Notify train that all passengers are in.
            StartCoroutine(train.Drive());
        }
    }

    private void HandlePassengerExitTrain(Person passegner)
    {
        passegner.InTrain(false);

        currentNumOfPassengersInTrain--;

        onNumOfPassengersUpdated.Raise(currentNumOfPassengersInTrain);


        if (currentNumOfPassengersInTrain == 0)
        {
            print("lets drive.");
            train.CloseDoors();

            //Notify train that all passengers are in or out
            StartCoroutine(train.Drive());
        }
    }

    public void SetMaxNumOfPassengersInTrain(int maxNumOfPassengersInTrain)
    {
        this.maxNumOfPassengersInTrain = maxNumOfPassengersInTrain;
    }


}
