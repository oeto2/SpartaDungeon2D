using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject TrickSceneObejct;
    [SerializeField] Material PlayerSpriteLitMaterial;

    public GameObject Player;
    private void Awake()
    {
        Instance = this;
    }

    //Start Player Trick
    public void StartTrick()
    {
        //SetActive false UIButtons;
        UIManager.Instance.HideMainButtons();
        //SetActive false Main Backround Image
        UIManager.Instance.HideMainBackGroundImage();

        TrickSceneObejct.SetActive(true);
    }

    public void TrickScenePlayerSetting()
    {
        //Change Player Material
        Player.GetComponent<SpriteRenderer>().material = PlayerSpriteLitMaterial;
    }
}
