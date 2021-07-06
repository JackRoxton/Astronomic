using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField, Range(0,1)]
    private float speed = 0.15f;
    private float horizontal;
    private float size; //transform.localscale = size * calcul;

    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(speed * horizontal, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
        if(asteroid != null)
        {
            Destroy(asteroid.gameObject);
            this.transform.localScale += Vector3.one * 0.4f /*à enlever*/;
        }
    }

    public void ChangeWeight(int weight)
    {
        //this.transform.localScale += Vector3.one * ?;
        //this.transform.postion += Vector3(0,?,0);
    }

}
