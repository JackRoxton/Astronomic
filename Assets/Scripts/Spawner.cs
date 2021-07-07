using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> asteroids = new List<GameObject>();

    [SerializeField]
    GameObject asteroid = null;
    [SerializeField]
    GameObject missile = null;

    public int phase = 1;
    bool sFlag = false, bFlag = false;

    Vector3 right, left;

    private void Start()
    {
        right = new Vector3(10, -2);
        left = new Vector3(-10, -2);
    }

    void Update()
    {
        if (sFlag == false && phase == 1)
            StartCoroutine(PhaseOne());

        if (sFlag == false && phase == 2)
            StartCoroutine(PhaseTwo());

        if (sFlag == false && phase == 3)
            StartCoroutine(PhaseThree());

        if (bFlag == false && phase == 4)
        {
            StartCoroutine(SendBoss());
            bFlag = true;
        }
    }

    IEnumerator PhaseOne()
    {
        int rand = Random.Range(0, 10);
        if(rand > 8)
            Instantiate(missile, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        
        else if (rand <= 3)
            if (Random.Range(0, 2) == 1)
                Instantiate(RandomAsteroid(), right - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
            else
                Instantiate(RandomAsteroid(), left - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
        else
        Instantiate(RandomAsteroid(), this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        sFlag = true;
        yield return new WaitForSeconds(Random.Range(1, 3));
        sFlag = false;
    }
    IEnumerator PhaseTwo()
    {
        if (Random.Range(0,10) >= 7)
            Instantiate(missile, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);

        if (Random.Range(0, 10) <= 7)
            Instantiate(RandomAsteroid(), this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);

        if (Random.Range(0, 10) <= 5)
            if (Random.Range(0, 2) == 1)
                Instantiate(RandomAsteroid(), right - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
            else
                Instantiate(RandomAsteroid(), left - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);

        sFlag = true;
        yield return new WaitForSeconds(Random.Range(1, 2));
        sFlag = false;
    }
    IEnumerator PhaseThree()
    {
        Instantiate(missile, this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        int rand = Random.Range(0, 10);
        if (rand < 5)
        if (rand <=1)
            if (Random.Range(0, 1) == 1)
                    Instantiate(RandomAsteroid(), right - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
                else
                    Instantiate(RandomAsteroid(), left - new Vector3(0, Random.Range(2, 5), 0), Quaternion.identity);
            else
            Instantiate(RandomAsteroid(), this.transform.position + new Vector3(Random.Range(-6, 6), 0, 0), Quaternion.identity);
        sFlag = true;
        yield return new WaitForSeconds(0.75f);
        sFlag = false;
    }
    IEnumerator SendBoss()
    {
        Instantiate(asteroids[0] /*boss*/, this.transform.position + new Vector3(Random.Range(-2, 2), 0, 0), Quaternion.identity);
        yield return null;
    }

    private GameObject RandomAsteroid()
    {
        int rand, astero;
        rand = Random.Range(0, 100);
        if (rand <= 6)
            astero = 1;
        else if (rand <= 14)
            astero = 2;
        else if (rand <= 20)
            astero = 3;
        else if (rand <= 28)
            astero = 4;
        else if (rand <= 36)
            astero = 5;
        else if (rand <= 44)
            astero = 6;
        else if (rand <= 54)
            astero = 7;
        else if (rand <= 64)
            astero = 8;
        else if (rand <= 74)
            astero = 9;
        else
            astero = 10;

        return asteroids[astero];
    }

}
