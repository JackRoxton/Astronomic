using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource source = null;

    public static AudioManager Instance = null;
    
    [SerializeField]
    AudioClip Impact = null;

    [SerializeField]
    AudioClip PowerUp = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            source.PlayOneShot(Impact, 0.35f);

        if (Input.GetKeyDown(KeyCode.L))
            source.PlayOneShot(PowerUp,0.2f);

    }*/

    public void Play()
    {
        source.Play();
    }

    public void PlayImpact()
    {
        source.PlayOneShot(Impact,0.35f);
    }

    public void PlayPowerUp()
    {
        source.PlayOneShot(PowerUp,0.2f);
    }
}
