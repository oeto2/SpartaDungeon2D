using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] GameObject[] InventorySlots;

    private void Start()
    {
        refreshInventorySlots();
    }

    public void refreshInventorySlots()
    {
        List<ItemData> haveItems = GameManager.Instance.Player.GetComponent<Inventory>().HaveItems;
        int count = 0;

        foreach(ItemData itemData in haveItems)
        {
            InvetorySlotData inventorySlotData = InventorySlots[count].GetComponent<InvetorySlotData>();
            inventorySlotData.ItemImage.sprite = haveItems[count].ItemImage;
            inventorySlotData.SlotItemData = itemData;
            count++;
        }
    }
}
