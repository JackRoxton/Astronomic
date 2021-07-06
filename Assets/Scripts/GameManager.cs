using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float gameTimer;
    [SerializeField]
    Spawner spawner = null;

    public GameManager Instance = null;
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
    void Update()
    {
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
        UIManager.GameOver();
    }

    public static float GetTimer()
    {
        return gameTimer;
    }
}
