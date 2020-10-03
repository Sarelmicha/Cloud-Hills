using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    [SerializeField] GameObject[] cells = null;

    private NavMeshAgent navMesh = null;
    private Animator anim = null;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position == navMesh.destination)
        {
            //anim.SetTrigger("idle");
            print("im in destiniation");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Train")
        {
            print("lets walk");
            navMesh.destination = cells[Random.Range(0, cells.Length)].transform.position;
            anim.SetTrigger("walk");
        }
    }
}
