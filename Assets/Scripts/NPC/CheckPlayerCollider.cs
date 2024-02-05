using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            GameManager.Instance.Player.GetComponent<PlayerState>().TriggerNpc = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            GameManager.Instance.Player.GetComponent<PlayerState>().TriggerNpc = false;
    }
}
