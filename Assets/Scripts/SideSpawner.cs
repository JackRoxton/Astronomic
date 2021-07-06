using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpawner : MonoBehaviour
{
    [SerializeField]
    public bool rightside;
    [SerializeField]
    GameObject sideAsteroid = null;

    public void SpawnSide()
    {
        if (rightside)
            Instantiate(sideAsteroid, this.transform.position - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
        else
            Instantiate(sideAsteroid, this.transform.position - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
    }
}
