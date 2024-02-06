using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] private GameObject[] MainBackGroundImage;

    [SerializeField] private Text PlayerNameText;
    [SerializeField] private Text JokeValueText;
    [SerializeField] private Text HpValueText;
    [SerializeField] private Text MissValueText;
    [SerializeField] private Text CandyValueText;
    [SerializeField] private Text PlayerLevelText;
    [SerializeField] private Text PlayerExpText;
    [SerializeField] private Slider PlayerExpSlider;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().GetCandyEvent += RefreshCandytext;
        RefreshCandytext();
        RefreshExpSlide();

        if (InfoManager.Instance != null)
            PlayerNameText.text = InfoManager.Instance.NicknameInputFeiled.text;
    }

    public void HideMainButtons()
    {
        foreach (GameObject btn in Buttons)
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

    public void RefreshStateText()
    {
        State playerState = GameManager.Instance.Player.GetComponent<PlayerState>().PlayerState_;

        JokeValueText.text = playerState.joke.ToString();
        HpValueText.text = playerState.hp.ToString();
        MissValueText.text = playerState.miss.ToString();
        PlayerLevelText.text = playerState.level.ToString();
    }

    public void RefreshCandytext() => CandyValueText.text = GameManager.Instance.candyNum.ToString();

    public void RefreshExpSlide()
    {
        State playerState = GameManager.Instance.Player.GetComponent<PlayerState>().PlayerState_;

        if (playerState.curExp == 0)
            PlayerExpSlider.value = 0;

        else
        {
            PlayerExpSlider.value = (float)playerState.curExp / playerState.maxExp;
            //Debug.Log((float)playerState.maxExp / playerState.curExp);
        }

        PlayerExpText.text = $"{playerState.curExp} / {playerState.maxExp}";
    }
}
