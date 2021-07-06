using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField, Range(0,1)]
    private float speed = 0.15f;
    private float horizontal;
    private float size;

    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(speed * horizontal, 0);
    }

    public void ChangeWeight(float weight)
    {
        this.transform.localScale += Vector3.one * weight;
        this.transform.position += new Vector3(0, weight / 10,0);
        size += weight;
    }

}
