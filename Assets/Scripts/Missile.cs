using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    float loss = -1;
    [SerializeField, Range(0, 1000)]
    float speed = 300;
    bool hit = false;
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterControler player = collision.gameObject.GetComponent<CharacterControler>();
        if(player != null)
        {
            if(!hit)
            player.ChangeWeight(loss);

            hit = true;
            Destroy(this.gameObject);
        }
    }
}
