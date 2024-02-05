using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniamtionController : MonoBehaviour
{
    Animator PlayerAnimator;

    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    public void Start()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().OnPrankEvent += StartPlayerPrankAnimation;
    }

    public void StartPlayerPrankAnimation() => PlayerAnimator.SetTrigger("Prank");
}
