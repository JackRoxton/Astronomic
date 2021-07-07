using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float gameTimer;
    [SerializeField]
    Spawner spawner = null;
    static UIManager uiMan=null;
    public GameManager Instance = null;
    bool tuto = true;
    /*private void Awake()
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
    }*/
    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            tuto = false;
            uiMan.DeactivateTuto();
            spawner.phase = 1;
        }
        if (tuto) return;
        gameTimer += Time.deltaTime;
        if (gameTimer >= 90)
            UIManager.WinScreen();
        else if (gameTimer >= 80)
            spawner.phase = 4;
        else if (gameTimer >= 60)
            spawner.phase = 3;
        else if (gameTimer >= 30)
            spawner.phase = 2;

    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        uiMan.GameOver();
    }

    public static float GetTimer()
    {
        return gameTimer;
    }
    public void TryAgain()
    {
        Debug.Log("load");
        gameTimer = 0f;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void SetUIMan(UIManager uiM)
    {
        uiMan = uiM;
    }
}