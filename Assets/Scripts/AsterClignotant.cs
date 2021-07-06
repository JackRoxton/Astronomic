using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterClignotant : MonoBehaviour
{
    private bool heavierThanPlayer;

    // Start is called before the first frame update
    void Start()
    {
        heavierThanPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (heavierThanPlayer)
        {
            this.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_EAFD24DB", Mathf.PingPong(2*Time.time, 1f));
        }
        else
        {
            this.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_185AB46", Mathf.PingPong(2*Time.time,1f));
        }
    }
}
