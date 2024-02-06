using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public string name;
    public string info;
    public Sprite ItemImage;
    public int jokeValue;
    public int hpValue;
    public int missValue;
    public int price;
    public bool isEquip;
}




