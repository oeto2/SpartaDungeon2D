using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject DrobItem;

    private void Start()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().OnPrankEvent += OnDropItem;
    }

    public void OnDropItem()
    {
        if (GameManager.Instance.Player.GetComponent<PlayerState>().TriggerNpc)
            Instantiate(DrobItem, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
    }

}
