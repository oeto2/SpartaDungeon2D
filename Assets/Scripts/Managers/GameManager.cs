using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAMESTATE
{
    MAIN,
    TRICK
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GAMESTATE eGameState = GAMESTATE.MAIN;
    [SerializeField] GameObject TrickSceneObejct;
    [SerializeField] Material PlayerSpriteLitMaterial;

    public GameObject Player;
    public Transform PlayerSpawnTransform;
    public Transform PlayerMainTransform;
    public int candyNum = 100;
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
        eGameState = GAMESTATE.TRICK;

        //PlayerSizeSetting
        Player.transform.position = PlayerSpawnTransform.position;
        Player.transform.localScale = new Vector2(3, 3);
    }

    public void EndTrick()
    {
        UIManager.Instance.ShowMainButtons();
        UIManager.Instance.ShowMainBackGroundImage();

        TrickSceneObejct.SetActive(false);
        eGameState = GAMESTATE.MAIN;
        
        Player.transform.position = PlayerMainTransform.position;
        Player.transform.localScale = new Vector2(6, 6);
    }

    public void TrickScenePlayerSetting()
    {
        //Change Player Material
        Player.GetComponent<SpriteRenderer>().material = PlayerSpriteLitMaterial;
    }

    public void GetCandy(int _num) => candyNum += _num;
}
