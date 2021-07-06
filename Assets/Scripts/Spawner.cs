using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;
    [SerializeField]
    GameObject missile;

    public int phase = 1;
    bool sFlag = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (sFlag == false && phase == 1)
            StartCoroutine(PhaseOne());

        if (sFlag == false && phase == 2)
            StartCoroutine(PhaseTwo());

        if (sFlag == false && phase == 3)
            StartCoroutine(PhaseThree());
    }

    IEnumerator PhaseOne()
    {
        if(Random.Range(0,10) > 8)
        Instantiate(missile, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        else
        Instantiate(asteroid, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        sFlag = true;
        yield return new WaitForSeconds(Random.Range(1, 3));
        sFlag = false;
    }
    IEnumerator PhaseTwo()
    {
        if (Random.Range(0, 10) > 7)
            Instantiate(missile, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        else
            Instantiate(asteroid, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        sFlag = true;
        yield return new WaitForSeconds(Random.Range(1, 2));
        sFlag = false;
    }
    IEnumerator PhaseThree()
    {
        if (Random.Range(0, 10) > 4)
            Instantiate(missile, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        else
            Instantiate(asteroid, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        sFlag = true;
        yield return new WaitForSeconds(1);
        sFlag = false;
    }
}
