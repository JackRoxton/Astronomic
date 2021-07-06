﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    int size = 100;
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterControler player = collision.gameObject.GetComponent<CharacterControler>();
        if (player != null)
        {
            player.ChangeWeight(size);
            Destroy(this.gameObject);
        }
    }
}
