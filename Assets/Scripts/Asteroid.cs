using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField, Range(0,30)]
    float size = 1;
    [SerializeField, Range(0,1000)]
    float speed = 300;

    Vector3 target;

    bool hit = false;
    bool heavierThanPlayer = true;
    void Start()
    {
        this.speed += Random.Range(-50f, 50f);

        target = new Vector3(Random.Range(-8f,8f),4.5f);
        target.x -= this.transform.position.x;
        target.y -= this.transform.position.y;
        target.Normalize();
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(target * speed);
    }
    void Update()
    {
        if (heavierThanPlayer)
        {
            this.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_EAFD24DB", Mathf.PingPong(2 * Time.time, 1f));
        }
        else
        {
            this.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_185AB46", Mathf.PingPong(2 * Time.time, 1f));
        }
        if (CharacterControler.SendWeight() < size && !heavierThanPlayer)
        {
            heavierThanPlayer = true;
            this.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_185AB46", 0f);
        }
        else if(CharacterControler.SendWeight()>size&&heavierThanPlayer)
        {
            heavierThanPlayer = false;
            this.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_EAFD24DB", 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterControler player = collision.gameObject.GetComponent<CharacterControler>();
        if (player != null)
        {
            if(!hit)
            player.ChangeWeight(size);

            hit = true;

            AudioManager.Instance.PlayPowerUp();

            Destroy(this.gameObject);
        }
    }
}
