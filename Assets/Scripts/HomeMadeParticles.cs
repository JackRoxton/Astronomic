using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMadeParticles : MonoBehaviour
{
    [SerializeField] GameObject star;
    List<GameObject> parts;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        parts = new List<GameObject>();
        for(int i = 0; i < 1000; i++)
        {
            Vector3 rndPos = new Vector3(Random.Range(-9f, 9f), Random.Range(-9f, 9f), 1f);
            GameObject tempStar = Instantiate(star, rndPos, Quaternion.identity);
            tempStar.transform.localScale =( (0.1f+50f/(i+50f)) )* Vector3.one;
            parts.Add(tempStar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (count)
        {
            case 0:
                for (int i = 0; i < Mathf.Floor((parts.Count - 1) / 10); i++){
                    if (parts[i].transform.position.y > 9f)
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, -9f - Random.Range(0, 1), 0f);
                    }
                    else
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, parts[i].transform.position.y + 0.001f, 0f);
                    }
                }
                count++;
                break;
            case 1:
                for (int i = 0; i < 3*Mathf.Floor((parts.Count - 1) / 10); i++)
                {
                    if (parts[i].transform.position.y > 9f)
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, -9f - Random.Range(0, 1), 0f);
                    }
                    else
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, parts[i].transform.position.y + 0.001f, 0f);
                    }
                }
                count++;
                break;
            case 2:
                for (int i = 0; i < 6*Mathf.Floor((parts.Count - 1) / 10); i++)
                {
                    if (parts[i].transform.position.y > 9f)
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, -9f - Random.Range(0, 1), 0f);
                    }
                    else
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, parts[i].transform.position.y + 0.001f, 0f);
                    }
                }
                count++;
                break;
            case 3:
                for (int i = 0; i < 9*Mathf.Floor((parts.Count - 1) / 10); i++)
                {
                    if (parts[i].transform.position.y > 9f)
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, -9f - Random.Range(0, 1), 0f);
                    }
                    else
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, parts[i].transform.position.y + 0.001f, 0f);
                    }
                }
                count++;
                break;
            case 4:
                for (int i = 0; i <parts.Count - 1; i++)
                {
                    if (parts[i].transform.position.y > 9f)
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, -9f - Random.Range(0, 1), 0f);
                    }
                    else
                    {
                        parts[i].transform.position = new Vector3(parts[i].transform.position.x, parts[i].transform.position.y + 0.001f, 0f);
                    }
                }
                count=0;
                break;
        }
    }
    private GameObject randomizedRepop(GameObject oldStar)
    {
        return oldStar;
    }
}
