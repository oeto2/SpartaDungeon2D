using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance = null;
    public InputField NicknameInputFeiled;
    [SerializeField] string playerName;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetPlayeName()
    {
        playerName = NicknameInputFeiled.text;
    }
}
