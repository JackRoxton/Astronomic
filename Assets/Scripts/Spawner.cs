using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;
    [SerializeField]
    GameObject missile;

    int phase = 1;
    bool sFlag = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (sFlag == false)
            StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Instantiate(asteroid, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        sFlag = true;
        yield return new WaitForSeconds(Random.Range(1,3));
        sFlag = false;
    }
}
