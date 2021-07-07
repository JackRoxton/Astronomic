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
    [SerializeField] GameObject panelGO=null, panelTuto=null;
    [SerializeField] Button tryAgain=null;

    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SetUIMan(this);
    }

    void Update()
    {
        TimerText.text = (90 - GameManager.GetTimer()).ToString();
        TimerSlider.value = GameManager.GetTimer();
    }

    public void GameOver()
    {
        panelGO.SetActive(true);
    }

    public static void WinScreen()
    {

    }
    public void DeactivateTuto()
    {
        panelTuto.SetActive(false);
    }
}
