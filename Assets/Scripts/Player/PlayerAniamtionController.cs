using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniamtionController : MonoBehaviour
{
    public Animator PlayerAnimator;
    
    public void Start()
    {
        GameManager.Instance.Player.GetComponent<PlayerController>().OnPrankEvent += StartPlayerPrankAnimation;
    }

    public void StartPlayerPrankAnimation() => PlayerAnimator.SetTrigger("Prank");
}
