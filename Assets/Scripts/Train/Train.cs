using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private float speed =  2f;
    [SerializeField] private float breakSpeed = 0.05f;

    [SerializeField] Station[] stations = null;
    [SerializeField] Door[] doors = null;
    [SerializeField] GameObject[] cells = null;

    [SerializeField] VoidEvent onTrainStopped = null;
    [SerializeField] VoidEvent onTrainStartDrive = null;

    [SerializeField] GameObject passengers = null;


    private bool isBreaksOn = false;
    private float trainSpeed;
    private bool isStoped = false;
    private int currentStationIndex = -1;


    private void Awake()
    {
        SetTrainSpeed(speed);
    }

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
        transform.position +=  Vector3.forward  * Time.deltaTime * trainSpeed * breakSpeed;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Station")
        {
            isBreaksOn = true;
        }

        else if (other.tag == "Stop Point" && !isStoped)
        {
            print("im here shtrudel");
            SetTrainSpeed(0);
            OpenDoors();
            print("currentStationIndex before inc" + currentStationIndex);
            currentStationIndex++;
            print("currentStationIndex after inc" + currentStationIndex);


            if (currentStationIndex == stations.Length)
            {
                currentStationIndex = 0;
            }


            ActivatePassengers();

            onTrainStopped.Raise();

            isStoped = true;
        }
    }

    private void ActivatePassengers()
    {
        for (int i = 0; i < passengers.transform.childCount; i++)
        {
            passengers.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OpenDoors()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor();
        }

    }

    public void CloseDoors()
    {
        foreach (Door door in doors)
        {
            door.CloseDoor();

        }
    }

    public IEnumerator Drive()
    {
        isBreaksOn = false;
        SetTrainSpeed(speed);
        yield return new WaitForSeconds(3f);
        isStoped = false;

    }

    public void SetTrainSpeed(float speed)
    {
        print("in set train speed");
        this.trainSpeed = speed;
        print("in set train speed and speed is now " + speed);

    }

    public Vector3 GetCellPosition(int cellIndex)
    {        
        return cells[cellIndex].transform.position;
    }

    public int GetRandomCellIndex()
    {
        int randomCell = UnityEngine.Random.Range(0, cells.Length);
        print("randomCell is " + randomCell);
        return randomCell;
    }

    public Station GetCurrentStations()
    {
        print("currentStationIndex is " + currentStationIndex);
        return this.stations[currentStationIndex];
    }




}
