using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
        if(asteroid != null)
        {
            Destroy(asteroid.gameObject);
            this.transform.localScale += Vector3.one * 0.4f;
        }
    }

}
