using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] GameObject[] InventorySlots;

    [Header("ItemInfoPanel")]
    [SerializeField] int CurItemInfoNum;
    [SerializeField] GameObject ItemInfoPanel;
    [SerializeField] Image ItemImage;
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemInfoText;
    [SerializeField] Text JokeValueText;
    [SerializeField] Text HpValueText;
    [SerializeField] Text MissValueText;

    private List<ItemData> PlayerHaveItems;
    private PlayerState PlayerStateScript;


    private void Awake()
    {
        PlayerHaveItems = GameManager.Instance.Player.GetComponent<Inventory>().HaveItems;
        PlayerStateScript = GameManager.Instance.Player.GetComponent<PlayerState>();
    }

    private void Start()
    {
        refreshInventorySlots();
    }

    public void refreshInventorySlots()
    {
        int count = 0;

        foreach (ItemData itemData in PlayerHaveItems)
        {
            InventorySlotData inventorySlotData = InventorySlots[count].GetComponent<InventorySlotData>();
            inventorySlotData.ItemImage.sprite = PlayerHaveItems[count].ItemImage;
            inventorySlotData.SlotItemData = itemData;

            //Setting Inventory Slot Button 
            Button invenSlotButton = InventorySlots[count].GetComponent<Button>();
            invenSlotButton.onClick.AddListener(() => SetItemInfoPanel(itemData, inventorySlotData.indexNum));
            count++;
        }
    }
    public void SetItemInfoPanel(ItemData _selctItem, int _itemIndex)
    {
        CurItemInfoNum = _itemIndex;
        ItemInfoPanel.SetActive(true);
        ItemImage.sprite = _selctItem.ItemImage;
        ItemNameText.text = _selctItem.name;
        ItemInfoText.text = _selctItem.info;
        JokeValueText.text = $"장난력 : {_selctItem.jokeValue}";
        HpValueText.text = $"체력 : {_selctItem.hpValue}";
        MissValueText.text = $"회피율 : {_selctItem.missValue}";
    }

    public void EquipItem()
    {
        ItemData slotItemData = InventorySlots[CurItemInfoNum].GetComponent<InventorySlotData>().SlotItemData;

        //Check off item is already Equip
        if (PlayerStateScript.EquipItem != null)
        {
            for(int i =0; i < PlayerHaveItems.Count; i++)
            {
                ItemData equipSlotItemData = InventorySlots[i].GetComponent<InventorySlotData>().SlotItemData;

                if (equipSlotItemData.isEquip)
                {
                    equipSlotItemData.isEquip = false;
                    InventorySlots[i].GetComponent<InventorySlotData>().EquipImageObject.SetActive(false);
                    PlayerStateScript.ApplyEquipItemSubValue(equipSlotItemData);
                }
            }
        }

        InventorySlots[CurItemInfoNum].GetComponent<InventorySlotData>().EquipImageObject.SetActive(true);
        //Equip Item to Player
        PlayerStateScript.EquipItem = slotItemData;
        PlayerStateScript.ApplyEquipItemAddValue(slotItemData);
        slotItemData.isEquip = true;

        //Print SystemMessage
        SystemMessageManager.Instance.SendSytemMessageText("아이템을 착용했습니다!"); 
    }
    public void UnequipItem()
    {
        if(PlayerStateScript.EquipItem != null)
        {
            InventorySlotData invetoySlotData = InventorySlots[CurItemInfoNum].GetComponent<InventorySlotData>();

            if (invetoySlotData.SlotItemData.name == PlayerStateScript.EquipItem.name)
            {
                //Check if the item is already Equip
                invetoySlotData.EquipImageObject.SetActive(false);
                invetoySlotData.SlotItemData.isEquip = false;
                PlayerStateScript.ApplyEquipItemSubValue(PlayerStateScript.EquipItem);
                PlayerStateScript.EquipItem = null;
                SystemMessageManager.Instance.SendSytemMessageText("아이템 장착 해제했습니다!");
            }
        }
    }
}
