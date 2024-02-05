using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateShopInfo : MonoBehaviour
{
    [SerializeField]private GameObject[] Slots;
    [SerializeField]private ItemData[] Items;
    [SerializeField]private List<Button> BuyButtons;

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
            shopSlotInfoScript.JokeValueText.text = $"장난력 : {Items[count].jokeValue}";
            shopSlotInfoScript.HpValueText.text = $"체력 : {Items[count].hpValue}";
            shopSlotInfoScript.MissValueText.text = $"회피율 : {Items[count].missValue}";

            BuyButtons.Add(shopSlotInfoScript.BuyButton);
            BuyButtons[count].onClick.AddListener(() => BuyItem(shopSlotInfoScript.indexNum));
            count++;
        }
    }

    public void BuyItem(int _itemNum)
    {
        ShopSlotInfo shopSlotInfoScript = Slots[_itemNum].GetComponent<ShopSlotInfo>();
        shopSlotInfoScript.HideButton();
    } 
}
