using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Parts
{
    private GameObject part;
    private Vector3 dir;
    private float life, scale, speed;
    public Parts(GameObject _part,Vector3 _dir ,float _life, float _scale ,float _speed)
    {
        part = _part;
        dir=_dir;
        life = _life;
        scale = _scale;
        speed = _speed;
    }
    public bool updatePart()
    {
        if (life <= 0f) return true;
        else
        {
            Debug.Log("Life before : " + life);
            life =life- Time.deltaTime;
            part.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_E58EE8ED", Mathf.PingPong(2 * Time.time, 1f));
            //part.transform.position = part.transform.position + life *speed* dir;
            part.transform.SetPositionAndRotation(part.transform.position + life *speed*Time.deltaTime* dir+new Vector3(0f,5f*Time.deltaTime,0f), Quaternion.identity);
            part.transform.localScale = life * scale * Vector3.one;
        }
        return false;
    }
    public void SetPart(Vector3 _dir, float _life,float _scale,float _speed)
    {
        dir = _dir;
        life = _life;
        scale = _scale;
        speed = _speed;
    }
    public void SetPosition(Vector3 _pos)
    {
        if (part != null) part.transform.position = _pos;
    }
}

public class ExploParts : MonoBehaviour
{
    static List<Parts> pullExplo;
    static List<Parts> activeExplo;
    [SerializeField] GameObject partTempl;
    static GameObject partTemplate;
    // Start is called before the first frame update
    void Start()
    {
        partTemplate = partTempl;
        pullExplo = new List<Parts>();
        pullExplo.Capacity = 128;
        activeExplo = new List<Parts>();
        activeExplo.Capacity = 128;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("active : "+activeExplo.Count+"   pull : "+pullExplo.Count);
        for(int i = 0; i < activeExplo.Count; i++)
        {
            if (activeExplo[i].updatePart())
            {
                Debug.Log("rangé");
                Parts p = activeExplo[i];
                activeExplo.RemoveAt(i);
                p.SetPart(Vector3.zero, 0f, 0f, 0f);
                p.SetPosition(new Vector3(100f, 100f, 0f));
                pullExplo.Add(p);
            }
        }
    }
    static public void Burst(Vector3 _pos, float taille = 1f)
    {
        if (taille > 1)
        {
            if (pullExplo.Count < 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    GameObject newP = Instantiate(partTemplate, new Vector3(100f, 100f, 0f), Quaternion.identity);
                    Parts p = new Parts(newP, Vector3.zero, 0f, 0f, 0f);
                    pullExplo.Add(p);
                }

            }
            float phase = Random.RandomRange(0f, 2f * Mathf.PI / 30f);
            for (int i = 0; i < 30; i++)
            {
                Parts p = pullExplo[0];
                p.SetPart(new Vector3(Mathf.Cos(phase + 2f * i * Mathf.PI / 30f), Mathf.Sin(phase + 2f * i * Mathf.PI / 30f), 0f), 1f, 3f, 10f * Random.Range(0.8f, 1.2f));
                p.SetPosition(_pos);
                pullExplo.RemoveAt(0);
                activeExplo.Add(p);

            }
        }else if(taille>0.1f){
            if (pullExplo.Count < 14)
            {
                for (int i = 0; i < 14; i++)
                {
                    GameObject newP = Instantiate(partTemplate, new Vector3(100f, 100f, 0f), Quaternion.identity);
                    Parts p = new Parts(newP, Vector3.zero, 0f, 0f, 0f);
                    pullExplo.Add(p);
                }

            }
            float phase = Random.RandomRange(0f, 2f * Mathf.PI / 14f);
            for (int i = 0; i < 14; i++)
            {
                Parts p = pullExplo[0];
                p.SetPart(new Vector3(Mathf.Cos(phase + 2f * i * Mathf.PI / 14f), Mathf.Sin(phase + 2f * i * Mathf.PI / 14f), 0f), 1f, 2f, 10f * Random.Range(0.8f, 1.2f));
                p.SetPosition(_pos);
                pullExplo.RemoveAt(0);
                activeExplo.Add(p);

            }
        }
        else if (taille > 0.01f)
        {
            if (pullExplo.Count < 7)
            {
                for (int i = 0; i < 7; i++)
                {
                    GameObject newP = Instantiate(partTemplate, new Vector3(100f, 100f, 0f), Quaternion.identity);
                    Parts p = new Parts(newP, Vector3.zero, 0f, 0f, 0f);
                    pullExplo.Add(p);
                }

            }
            float phase = Random.RandomRange(0f, 2f * Mathf.PI / 7f);
            for (int i = 0; i < 7; i++)
            {
                Parts p = pullExplo[0];
                p.SetPart(new Vector3(Mathf.Cos(phase + 2f * i * Mathf.PI / 7f), Mathf.Sin(phase + 2f * i * Mathf.PI / 7f), 0f), 1f, 1f, 10f * Random.Range(0.8f, 1.2f));
                p.SetPosition(_pos);
                pullExplo.RemoveAt(0);
                activeExplo.Add(p);

            }
        }
        else 
        {
            if (pullExplo.Count < 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    GameObject newP = Instantiate(partTemplate, new Vector3(100f, 100f, 0f), Quaternion.identity);
                    Parts p = new Parts(newP, Vector3.zero, 0f, 0f, 0f);
                    pullExplo.Add(p);
                }

            }
            float phase = Random.RandomRange(0f, 2f * Mathf.PI / 4f);
            for (int i = 0; i < 4; i++)
            {
                Parts p = pullExplo[0];
                p.SetPart(new Vector3(Mathf.Cos(phase + 2f * i * Mathf.PI / 4f), Mathf.Sin(phase + 2f * i * Mathf.PI / 4f), 0f), 1f, 1f, 10f* Random.Range(0.8f, 1.2f));
                p.SetPosition(_pos);
                pullExplo.RemoveAt(0);
                activeExplo.Add(p);
            }
        }
    }
}
