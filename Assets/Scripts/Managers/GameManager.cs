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

    public void TrickScenePlayerSetting()
    {
        //Change Player Material
        Player.GetComponent<SpriteRenderer>().material = PlayerSpriteLitMaterial;
    }
}
