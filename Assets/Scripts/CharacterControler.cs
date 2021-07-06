using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField, Range(0,0.1f)]
    private float speed = 0.10f;
    private float horizontal;
    private static float size = 5;

    void Update()
    {

        if(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.D))
        {

        }
        else if(Input.GetKey(KeyCode.Q))
        {
            this.transform.position = new Vector3(Mathf.Clamp(
            this.transform.position.x -speed,
            -9 + this.transform.localScale.x * 0.0903266f,
            9 - this.transform.localScale.x * 0.0903266f),
            this.transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector3(Mathf.Clamp(
            this.transform.position.x + speed,
            -9 + this.transform.localScale.x * 0.0903266f,
            9 - this.transform.localScale.x * 0.0903266f),
            this.transform.position.y);
        }
    }

    public void ChangeWeight(float weight)
    {
        if(weight > size)
        {
            GameManager.GameOver();
            AudioManager.Instance.PlayImpact();
            Destroy(this.gameObject);
        }

        if(weight < 0)
        {
            AudioManager.Instance.PlayImpact();
        }

        this.transform.localScale += Vector3.one * weight;
        this.transform.position += new Vector3(0, weight / 12,0);
        size += weight;
    }

    public static float SendWeight()
    {
        return size;
    }

}
