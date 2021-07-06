using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer;
    [SerializeField]
    Spawner spawner;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60)
            spawner.phase = 3;
        else if (timer >= 30)
            spawner.phase = 2;
        
    }
}
