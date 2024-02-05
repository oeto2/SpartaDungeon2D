using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] private GameObject[] MainBackGroundImage;

    [SerializeField] private Text JokeValueText;
    [SerializeField] private Text HpValueText;
    [SerializeField] private Text MissValueText;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void HideMainButtons()
    {
         foreach(GameObject btn in Buttons)
        {
            btn.SetActive(false);
        }
    }

    public void ShowMainButtons()
    {
        foreach (GameObject btn in Buttons)
        {
            btn.SetActive(true);
        }
    }

    public void HideMainBackGroundImage()
    {
        foreach (GameObject backBG in MainBackGroundImage)
        {
            backBG.SetActive(false);
        }
    }

    public void ShowMainBackGroundImage()
    {
        foreach (GameObject backBG in MainBackGroundImage)
        {
            backBG.SetActive(true);
        }
    }

    public void RefreshStateText(int _jokeValue, int _hpValue, int _missValue)
    {
        JokeValueText.text = _jokeValue.ToString();
        HpValueText.text = _hpValue.ToString();
        MissValueText.text = _missValue.ToString();
    }
}
