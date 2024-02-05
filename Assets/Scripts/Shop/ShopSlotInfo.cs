using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotInfo : MonoBehaviour
{
    public int indexNum;
    public Image ItemImage;
    public Text ItemNameText;
    public Text ItemInfoText;
    public Text JokeValueText;
    public Text HpValueText;
    public Text MissValueText;
    public Text PriceText;
    public Button BuyButton;
    public GameObject BuyButtonObject;

    public void HideButton() => BuyButtonObject.SetActive(false);
}
