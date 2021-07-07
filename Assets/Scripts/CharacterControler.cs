using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField, Range(0,0.1f)]
    private float speed = 0.10f;
    private float horizontal;
    private static float size = 0.6f;
    private float oscilCenter = 0f;
    public static bool timeOver = false;
    [SerializeField]
    ParticleSystem ps;
    void Start()
    {
        this.transform.localScale = Vector3.one * 2*Mathf.Pow(0.75f * size /(Mathf.PI*150) , 1f / 3f);
        oscilCenter = this.gameObject.transform.position.y;
    }
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, oscilCenter + 0.1f*Mathf.Sin(10f*Time.time)*Mathf.Sin(8f*Time.time));
        if (timeOver)
        {
            oscilCenter -= Time.deltaTime*3f;
            return;
        }
        if((Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
        {

        }
        else if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector3(Mathf.Clamp(
            this.transform.position.x -speed,
            -9 + this.transform.localScale.x * 3.3f,
            9 - this.transform.localScale.x * 3.3f),
            this.transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = new Vector3(Mathf.Clamp(
            this.transform.position.x + speed,
            -9 + this.transform.localScale.x *3.3f,
            9 - this.transform.localScale.x *3.3f),
            this.transform.position.y);
        }
        ps.transform.localScale = this.transform.localScale;
    }

    public void ChangeWeight(float weight)
    {
        if(weight > size||size+weight<0f)
        {
            GameManager.GameOver();
            AudioManager.Instance.PlayImpact();
            Destroy(this.gameObject);
        }else if(weight < 0)
        {
            AudioManager.Instance.PlayImpact();
        }
        else
        {
            size += weight;
            this.transform.localScale = Vector3.one *2f* Mathf.Pow(0.75f * size /(150f* Mathf.PI) , 1f / 3f);
        }
        Debug.Log(size);

    }

    public static float SendWeight()
    {
        return size;
    }

}
