using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterClignotant : MonoBehaviour
{
    private bool heavierThanPlayer;
    [SerializeField]CharacterControler charControl;

    // Start is called before the first frame update
    void Start()
    {
        heavierThanPlayer = true;
        charControl = GameObject.Find("Player").GetComponent<CharacterControler>();
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
