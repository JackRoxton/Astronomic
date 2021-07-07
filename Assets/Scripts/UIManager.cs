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
    [SerializeField] GameObject panelGO=null, panelTuto=null, panelIGUI=null, fadeInPanel=null, resultPanel=null;
    [SerializeField] Button tryAgain=null, mainMenu=null, tryagend=null;
    [SerializeField] Sprite[] endingsBG = null;
    public static bool fadeIn = false, fadeOut=false;
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SetUIMan(this);
    }

    void Update()
    {
        if (fadeInPanel.GetComponent<Image>().color.a >= 255f)
        {
            fadeIn = false;
            DisplayResults(CharacterControler.SendWeight());
        }
        else if (fadeIn)
        {
            Color tmpCol = fadeInPanel.GetComponent<Image>().color;
            tmpCol.a = fadeInPanel.GetComponent<Image>().color.a + 12f;
            fadeInPanel.GetComponent<Image>().color=tmpCol;
        }
        else if (fadeInPanel.GetComponent<Image>().color.a > 0)
        {
            Color tmpCol = fadeInPanel.GetComponent<Image>().color;
            tmpCol.a = fadeInPanel.GetComponent<Image>().color.a - 12f;
            fadeInPanel.GetComponent<Image>().color = tmpCol;
        }
        TimerText.text = (90 - GameManager.GetTimer()).ToString();
        TimerSlider.value = GameManager.GetTimer();
    }

    public void GameOver()
    {
        panelGO.SetActive(true);
    }
    public void DeactivateTuto()
    {
        panelTuto.SetActive(false);
    }
    public void SetIGUI(bool active)
    {
        panelIGUI.SetActive(active);
    }
    private void DisplayResults(float result)
    {
        if (result >= 30f)
        {
            //annihilation totale
        }else if (result > 1.6f) {
            //cratère
        }
        else
        {
            //plouf
        }
    }
}
