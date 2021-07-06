using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Button Play = null, Credits = null, Quit = null;
    [SerializeField]
    Text Title = null;
    [SerializeField]
    GameObject Background = null;

    bool credits = false;

    void Start()
    {
        Play.onClick.AddListener(PlayClick);
        Credits.onClick.AddListener(CreditsClick);
        Quit.onClick.AddListener(QuitClick);
    }

    void Update()
    {
        if (credits && Input.GetKeyDown("escape"))
        {
            Play.gameObject.SetActive(true);
            Credits.gameObject.SetActive(true);
            Quit.gameObject.SetActive(true);
            Title.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);

            credits = false;
            //enlever les crédits
        }
    }

    void PlayClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void CreditsClick()
    {
        Play.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);

        credits = true;
        //afficher crédits
        
    }

    void QuitClick()
    {
        Application.Quit();
    }

}
