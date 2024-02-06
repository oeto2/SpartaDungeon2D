using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> HaveItems;

    public void GetItem(ItemData _getItemObejct)
    {
        HaveItems.Add(_getItemObejct);
    }
}
