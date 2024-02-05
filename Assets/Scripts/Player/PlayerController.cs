using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> PlayerMoveEvent;
    public bool enablePrank = true;
    Rigidbody2D PlayerRigidbody2D;
    Vector2 PlayerMoveVelocity;
    SpriteRenderer PlayerSpriteRenderer;
    PlayerState PlayerStateScript;


    //Events
    public event Action OnPrankEvent;
    public event Action GetCandyEvent;

    private void Awake()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        PlayerStateScript = GetComponent<PlayerState>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.eGameState == GAMESTATE.TRICK)
            ApplyPlayerMoveSpeed();
    }

    //Call Get Candy Event
    public void CallGetCandyEvent()
    {
        GetCandyEvent?.Invoke();
    }

    //Player Move Input
    public void OnMove(InputAction.CallbackContext _context)
    {
        PlayerMoveVelocity = _context.ReadValue<Vector2>();
        FlipPlayerSprite(_context.ReadValue<Vector2>());
    }

    //Flip Player Sprite
    public void FlipPlayerSprite(Vector2 _vec)
    {
        if (_vec.x > 0)
            PlayerSpriteRenderer.flipX = false;
        else if (_vec.x < 0)
            PlayerSpriteRenderer.flipX = true;
    }

    //Apply Player Move Value
    public void ApplyPlayerMoveSpeed()
    {
        PlayerRigidbody2D.velocity = PlayerMoveVelocity * PlayerStateScript.PlayerMoveSpeed;
    }


    //Start Prank
    public void OnPrank(InputAction.CallbackContext _context)
    {
        if (_context.started && GameManager.Instance.eGameState == GAMESTATE.TRICK)
        {
            if (enablePrank)
            {
                OnPrankEvent?.Invoke();
                StartCoroutine(DealyEnablePrankSetTrue());
            }
        }
    }

    //enablePrank Set true Delay
    IEnumerator DealyEnablePrankSetTrue()
    {
        if (enablePrank)
        {
            enablePrank = false;
            yield return new WaitForSeconds(PlayerStateScript.PlayerPrankRate);
            enablePrank = true;
        }
        yield return null;
    }
}
