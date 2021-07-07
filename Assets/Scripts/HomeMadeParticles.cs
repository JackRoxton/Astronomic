using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMadeParticles : MonoBehaviour
{
    [SerializeField] GameObject star;
    List<GameObject> parts;
    
    // Start is called before the first frame update
    void Start()
    {
        parts = new List<GameObject>();
        for(int i = 0; i < 1000; i++)
        {
            GameObject tempStar = new GameObject();
            tempStar = star;
            tempStar.transform.localScale =( 0.1f+1f/(i+1f) )* Vector3.one;
            Vector3 rndPos = new Vector3(Random.Range(-9f, 9f), Random.Range(-6f, 6f),1f);

            Instantiate(tempStar, rndPos, Quaternion.identity);
            parts.Add(tempStar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<parts.Count-1;i++)
        {
            if (parts[i].transform.position.y > 9f)
            {
                parts[i].transform.position = new Vector3(Random.Range(-9f, 9f), -6.01f, 1f);
                parts[i].transform.localScale = 1 / Random.Range(100,900) * Vector3.one;
            }
            else
            {
                parts[i].transform.position = new Vector3(parts[i].transform.position.x, parts[i].transform.position.y+0.5f, 0f);
            }
        }
    }
    private GameObject randomizedRepop(GameObject oldStar)
    {
        return oldStar;
    }
}
