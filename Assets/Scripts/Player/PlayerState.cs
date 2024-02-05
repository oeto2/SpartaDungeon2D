using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    public int joke = 10;
    public int hp = 100;
    public int miss = 10;

    public State(int _joke, int _hp, int _miss)
    {
        joke = _joke;
        hp = _hp;
        miss = _miss;
    }

    public void AddJoke(int _value) => joke += _value;
    public void AddHp(int _value) => hp += _value;
    public void AddMiss(int _value) => miss += _value;
}


public class PlayerState : MonoBehaviour
{
    [SerializeField] private State PlayerState_ = new State(10, 100, 10);

    private void Start()
    {
        //Refresh State Text
        UIManager.Instance.RefreshStateText(PlayerState_.joke, PlayerState_.hp, PlayerState_.miss);
    }
}
