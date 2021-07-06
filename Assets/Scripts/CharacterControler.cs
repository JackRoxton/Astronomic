using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField, Range(0,1)]
    private float speed = 0.10f;
    private float horizontal;
    private static float size = 5;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        this.transform.position = new Vector3(Mathf.Clamp(
            this.transform.position.x + speed * horizontal,
            -9 + this.transform.localScale.x * 0.0903266f,
            9 - this.transform.localScale.x * 0.0903266f),
            this.transform.position.y);
    }

    public void ChangeWeight(float weight)
    {
        if(weight > size)
        {
            GameManager.GameOver();
            Destroy(this.gameObject);
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
