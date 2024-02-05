using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            //if Get Candy
            case "Candy":
                Candy candyScript = collision.GetComponent<Candy>();
                if (candyScript.enableGetCandy)
                {
                    //Add Candy Total num
                    GameManager.Instance.GetCandy(candyScript.candyValue);
                    GetComponent<PlayerController>().CallGetCandyEvent();
                    Destroy(collision.gameObject);
                }
                break;
        }
    }
}
