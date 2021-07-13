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
            life =life- Time.deltaTime;
            part.GetComponent<SpriteRenderer>().material.SetFloat("Vector1_E58EE8ED", Mathf.PingPong(4f*Time.time, 1f));
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
        pullExplo.Capacity = 256;
        activeExplo = new List<Parts>();
        activeExplo.Capacity = 256;

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < activeExplo.Count; i++)
        {
            if (activeExplo[i].updatePart())
            {
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
        int tailleRef = 0;
        if (taille > 28f) tailleRef = 60;
        else if (taille > 11f) tailleRef = 50;
        else if (taille > 2f) tailleRef = 40;
        else if (taille > 1.5f) tailleRef = 30;
        else if (taille > 1.1f) tailleRef = 25;
        else if (taille > 0.2f) tailleRef = 15;
        else if (taille > 0.06f) tailleRef = 10;
        else if (taille > 0.03f) tailleRef = 8;
        else if (taille > 0.01f) tailleRef = 6;
        else if (taille > 0.003f) tailleRef = 5;
        else tailleRef = 4;
        if (pullExplo.Count < tailleRef)
        {
            for (int i = 0; i <tailleRef; i++)
            {
                GameObject newP = Instantiate(partTemplate, new Vector3(100f, 100f, 0f), Quaternion.identity);
                Parts p = new Parts(newP, Vector3.zero, 0f, 0f, 0f);
                pullExplo.Add(p);
            }

        }
        float phase = Random.Range(0f, 2f * Mathf.PI / (float)tailleRef);
        for (int i = 0; i < tailleRef; i++)
        {
            Parts p = pullExplo[0];
            float rndScale = Random.Range(0.8f, 1.2f);
            p.SetPart(new Vector3(Mathf.Cos(phase + 2f * i * Mathf.PI / (float)tailleRef), Mathf.Sin(phase + 2f * i * Mathf.PI / (float)tailleRef), 0f), 1f, (float)tailleRef*rndScale/10f, 6f *(2f-rndScale));
            p.SetPosition(new Vector3(_pos.x,_pos.y, Mathf.Pow(-1,i))+ 6f * (2f - rndScale)*Time.deltaTime* new Vector3(Mathf.Cos(phase + 2f * i * Mathf.PI / (float)tailleRef), Mathf.Sin(phase + 2f * i * Mathf.PI / (float)tailleRef), 0f));
            pullExplo.RemoveAt(0);
            activeExplo.Add(p);
        }
    }
}
