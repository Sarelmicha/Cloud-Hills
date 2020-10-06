using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private GameObject startRandomPosition = null;

    public Vector3 GetRadomPositionInStation()
    {
        return startRandomPosition.transform.position + new Vector3(0, 0, Random.Range(-0.45f, 0.45f));
    }
}
