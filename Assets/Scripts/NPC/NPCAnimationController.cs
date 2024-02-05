using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    Animator NpcAnimator;
    PlayerState PlayerStateScript;
    PlayerController PlayerControllerScript;

    private void Awake()
    {
        NpcAnimator = GetComponentInChildren<Animator>();
        PlayerStateScript = GameManager.Instance.Player.GetComponent<PlayerState>();
        PlayerControllerScript = GameManager.Instance.Player.GetComponent<PlayerController>();
    }

    private void Start()
    {
        PlayerControllerScript.OnPrankEvent += StartNpcSurprisedAniamtion;
    }

    public void StartNpcSurprisedAniamtion()
    {
        if(PlayerStateScript.TriggerNpc)
        {
            NpcAnimator.SetTrigger("Surprised");
        }
    }
}
