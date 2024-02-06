using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
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
            shopSlotInfoScript.JokeValueText.text = $"�峭�� : {Items[count].jokeValue}";
            shopSlotInfoScript.HpValueText.text = $"ü�� : {Items[count].hpValue}";
            shopSlotInfoScript.MissValueText.text = $"ȸ���� : {Items[count].missValue}";

            BuyButtons.Add(shopSlotInfoScript.BuyButton);
            BuyButtons[count].onClick.AddListener(() => BuyItem(shopSlotInfoScript.indexNum));
            count++;
        }
    }

    public void BuyItem(int _itemNum)
    {
        ShopSlotInfo shopSlotInfoScript = Slots[_itemNum].GetComponent<ShopSlotInfo>();

        if (GameManager.Instance.candyNum >= Items[_itemNum].price)
        {
            SystemMessageManager.Instance.SendSytemMessageText("�������� �����߽��ϴ�!");
            GameManager.Instance.candyNum -= Items[_itemNum].price;
            UIManager.Instance.RefreshCandytext();

            //Add Item to Player Invetory
            GameManager.Instance.Player.GetComponent<Inventory>().GetItem(Items[_itemNum]);
            shopSlotInfoScript.HideButton();
        }

        else if (GameManager.Instance.candyNum < Items[_itemNum].price)
        {
            SystemMessageManager.Instance.SendSytemMessageText("ĵ�� �����մϴ�!");
        }
    } 
}
