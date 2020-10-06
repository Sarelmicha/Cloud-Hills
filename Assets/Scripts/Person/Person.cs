using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{

    [SerializeField] Train train = null;


    private NavMeshAgent navMesh = null;
    private Animator anim = null;

    private int currentCellIndex;
    private bool inTrain = false;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
       
        if (navMesh.destination == transform.position)
        {
            return;
        }

        if (inTrain)
        {          
            anim.SetTrigger("idle");
            print("im in destiniation");
           
        }
    }

    public void HandlePassenger()
    {
        if (inTrain)
        {
            ExitTrain();
        }

        else
        {
            EnterTrain();
        }
    }

    private void EnterTrain()
    {
    
        print("lets walk");
        currentCellIndex = train.GetRandomCellIndex();
        SetDestination(train.GetCellPosition(currentCellIndex));
        anim.SetTrigger("walk");
    }

    private void ExitTrain()
    {
        print("im here!");

        //set passenger positon to cell position
        SetPosition(train.GetCellPosition(currentCellIndex));

        //Set new destination of passenger in station
        SetDestination(train.GetCurrentStations().GetRadomPositionInStation());       

    }



    public void InTrain(bool inTrain)
    {
        this.inTrain = inTrain;
    }

    public bool InTrain()
    {
        return this.inTrain;
    }

    public void SetDestination(Vector3 destination)
    {
        navMesh.destination = destination;
    }

    public void SetPosition(Vector3 positon)
    {    
        navMesh.Warp(positon);
        
    }

    public int GetCurrentCellIndex()
    {
        return this.currentCellIndex;
    }
}
