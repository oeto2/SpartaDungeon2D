using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class State
{
    public int joke = 10;
    public int hp = 100;
    public int miss = 10;
    public int level = 1;
    public int curExp = 0;
    public int maxExp = 5;

    public State(int _joke, int _hp, int _miss)
    {
        joke = _joke;
        hp = _hp;
        miss = _miss;
    }

    public void AddJoke(int _value) => joke += _value;
    public void AddHp(int _value) => hp += _value;
    public void AddMiss(int _value) => miss += _value;

    public void SubJoke(int _value) => joke -= _value;
    public void SubHp(int _value) => hp -= _value;
    public void SubMiss(int _value) => miss -= _value;

}
public class PlayerState : MonoBehaviour
{
    public State PlayerState_ = new State(10, 100, 10);
    
    [Header("PrankState")]
    [SerializeField] private bool triggerNpc;
    [SerializeField] float playerMoveSpeed;
    [SerializeField] float playerPrankRate;
    public ItemData EquipItem;

    private PlayerController PlayerControllerScript;

    public float PlayerMoveSpeed
    {
        set { playerMoveSpeed = value; }
        get { return playerMoveSpeed; }
    }
    
    public float PlayerPrankRate
    {
        set { PlayerPrankRate = value; }
        get { return playerPrankRate; }
    }

    //Property
    public bool TriggerNpc
    {
        set { triggerNpc = value; }
        get { return triggerNpc; }
    }

    private void Awake()
    {
        PlayerControllerScript = gameObject.GetComponent<PlayerController>();
    }

    private void Start()
    {
        //Refresh State Text
        UIManager.Instance.RefreshStateText();

        PlayerControllerScript.OnPrankEvent += GetExp;
    }

    public void ApplyEquipItemAddValue(ItemData _equipItem)
    {
        PlayerState_.AddJoke(_equipItem.jokeValue);
        PlayerState_.AddHp(_equipItem.hpValue);
        PlayerState_.AddMiss(_equipItem.missValue);
    }

    public void ApplyEquipItemSubValue(ItemData _equipItem)
    {
        PlayerState_.SubJoke(_equipItem.jokeValue);
        PlayerState_.SubHp(_equipItem.hpValue);
        PlayerState_.SubMiss(_equipItem.missValue);
    }

    public void GetExp()
    {
        PlayerState_.curExp += 5;

        //Player LevelUp Condition
        if (PlayerState_.curExp >= PlayerState_.maxExp)
            LevelUp();

        UIManager.Instance.RefreshExpSlide();
    }

    public void LevelUp()
    {
        UIManager.Instance.RefreshStateText();

        PlayerState_.level++;
        PlayerState_.curExp -= PlayerState_.maxExp;
        PlayerState_.maxExp = PlayerState_.level * 5;
    }
}
