using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{

    [SerializeField] Train train = null;
    [SerializeField] private Station currentStation = null;

    private NavMeshAgent navMesh = null;
    private Animator anim = null;

    
    private int currentCellIndex = 0;

    private bool inTrain = false;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (!navMesh.pathPending)
        {
            if (navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                if (!navMesh.hasPath || navMesh.velocity.sqrMagnitude == 0f)
                {
                   //TriggerIdleAnimation();
                }
            }
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
        
    }

    private void ExitTrain()
    {

        //set passenger positon to cell position
        SetPosition(train.GetCellPosition(currentCellIndex));

        //Set new destination of passenger in station
        currentStation = train.GetCurrentStations(); 
        
        //Set destination of a random spot in new station
        SetDestination(currentStation.GetRadomPositionInStation());       

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
        TriggerWalkAnimatiom();
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

    public Station GetCurrentStation()
    {
        return this.currentStation;
    }

    public void TriggerWalkAnimatiom()
    {
        anim.SetTrigger("walk");
    }

    public void TriggerIdleAnimation()
    {
        anim.SetTrigger("idle");

    }
}
