using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCounter : MonoBehaviour
{
    [SerializeField] private Train train = null;
    private int maxNumOfPassengersInTrain = 0;
    private int currentNumOfPassengersInTrain = 0;

    private void Awake()
    {
        maxNumOfPassengersInTrain = GameObject.FindGameObjectsWithTag("Person").Length;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {

            
            Person passegner = other.GetComponent<Person>();

            if (passegner.InTrain())
            {
                passegner.InTrain(false);

                currentNumOfPassengersInTrain--;

                if (currentNumOfPassengersInTrain == 0)
                {
                    print("lets drive.");
                    train.CloseDoors();

                    //Notify train that all passengers are in or out
                    StartCoroutine(train.Drive());
                }
            }

            else
            {
                passegner.InTrain(true);

                currentNumOfPassengersInTrain++;

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

          
        }
    }


}
