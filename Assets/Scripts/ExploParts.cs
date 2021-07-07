using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Parts
{
    GameObject part;
    Vector3 dir;
    float life;
    float scale;
    public Parts(GameObject _part,Vector3 _dir , float _scale )
    {
        part = _part;
        dir=_dir;
        life = 0.7f;
        scale = _scale;
    }
    public bool updatePart()
    {
        if (life < 0f) return true;
        else
        {
            life -= Time.deltaTime;
            part.transform.position += life * dir;
            part.transform.localScale = life * scale * Vector3.one;
        }
        return false;
    }
    public void ResetPart(Vector3 _dir)
    {
        dir = Vector3.zero;
        life = 0f;
        scale = 1f;
    }
}

public class ExploParts : MonoBehaviour
{
    List<Parts> pullExplo;
    List<Parts> activeExplo;
    [SerializeField] GameObject partTemplate;
    // Start is called before the first frame update
    void Start()
    {
        pullExplo = new List<Parts>();
        pullExplo.Capacity = 128;
        activeExplo = new List<Parts>();
        activeExplo.Capacity = 128;

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < activeExplo.Count - 1; i++)
        {
            if (activeExplo[i].updatePart())
            {
                pullExplo.Add(activeExplo[i]);
                activeExplo.RemoveAt(i);
                pullExplo[pullExplo.Count - 1].ResetPart(Vector3.zero);
            }
        }
    }
    public void Burst(Vector3 _pos, float taille = 1f)
    {
        if (taille > 10)
        {
            if (pullExplo.Count < 20)
            {
                for(int i = 0; i < 21; i++)
                {
                    Parts p = new Parts(partTemplate,Vector3.zero,0f );
                    pullExplo.Add(p);
                }
                
            }
            for(int i = 0; i < 20; i++)
            {
                Parts p = pullExplo[0];
                
            }
        }
    }
}
