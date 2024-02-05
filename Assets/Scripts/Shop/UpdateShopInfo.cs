using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateShopInfo : MonoBehaviour
{
    [SerializeField]private GameObject[] Slots;
    [SerializeField]private ItemData[] Items;

    private void Start()
    {
        RefreshShopInfo();
    }

    //Update Shop SlotDatas
    public void RefreshShopInfo()
    {
        int count = 0;

        foreach (GameObject gameObjcet in Slots)
        {
            ShopSlotInfo shopSlotInfoScript = gameObjcet.GetComponent<ShopSlotInfo>();
            shopSlotInfoScript.ItemImage.sprite = Items[count].ItemImage;
            shopSlotInfoScript.ItemNameText.text = Items[count].name;
            shopSlotInfoScript.ItemInfoText.text = Items[count].info;
            shopSlotInfoScript.PriceText.text = Items[count].price.ToString();
            shopSlotInfoScript.JokeValueText.text = $"�峭�� : {Items[count].jokeValue}";
            shopSlotInfoScript.HpValueText.text = $"ü�� : {Items[count].hpValue}";
            shopSlotInfoScript.MissValueText.text = $"ȸ���� : {Items[count].missValue}";
            count++;
        }
    }
}
