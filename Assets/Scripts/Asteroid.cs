using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size;
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
