using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rafale : MonoBehaviour
{
    [SerializeField]
    List<GameObject> rafale = new List<GameObject>();

    void Start()
    {
        Vector3 tar = new Vector3(Random.Range(-8f, 8f), 4.5f);
        float spd = Random.Range(-50f, 50f);
        float diff = Random.Range(-0.8f, 0.8f);
        foreach (GameObject go in rafale)
        {
            go.GetComponent<Asteroid>().target = tar;
            go.GetComponent<Asteroid>().target.x -= this.transform.position.x + diff;
            diff += Random.Range(-0.8f, 0.8f);
            go.GetComponent<Asteroid>().target.y -= this.transform.position.y;
            go.GetComponent<Asteroid>().target.Normalize();
            go.GetComponent<Asteroid>().speed += spd;
            go.GetComponent<Rigidbody2D>().AddForce(go.GetComponent<Asteroid>().target * go.GetComponent<Asteroid>().speed);
        }
    }
}
