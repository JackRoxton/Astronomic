using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text TimerText = null;
    [SerializeField]
    Slider TimerSlider = null;

    void Start()
    {
        
    }

    void Update()
    {
        TimerText.text = (90 - GameManager.GetTimer()).ToString();
        TimerSlider.value = GameManager.GetTimer();
    }

    public static void GameOver()
    {

    }

    public static void WinScreen()
    {

    }
}
