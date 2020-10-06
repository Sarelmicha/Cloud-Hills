using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private GameObject startRandomPosition = null;

    [SerializeField] private int stationIndex;
    

    public Vector3 GetRadomPositionInStation()
    {
        return startRandomPosition.transform.position + new Vector3(Random.Range(-3f,3f), 0, Random.Range(-8f, 8f));
    }

    public int GetStationIndex()
    {
        return this.stationIndex;
    }

}
