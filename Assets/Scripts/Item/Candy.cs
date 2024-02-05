using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Candy : MonoBehaviour
{
    Rigidbody2D CandyRigidbody2D;

    public int candyValue = 10;
    public bool enableGetCandy = false;

    private void Awake()
    {
        CandyRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(EnableGetCandySetTrue());
        candyValue += GameManager.Instance.Player.GetComponent<PlayerState>().PlayerState_.joke;
    }

    IEnumerator EnableGetCandySetTrue()
    {
        yield return new WaitForSeconds(1f);
        enableGetCandy = true;
    }
}
