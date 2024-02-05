using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> PlayerMoveEvent;
    Rigidbody2D PlayerRigidbody2D;
    [SerializeField] float playerMoveSpeed;
    Vector2 PlayerMoveVelocity;
    SpriteRenderer PlayerSpriteRenderer;

    //Events
    public event Action OnPrankEvent;

    private void Awake()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.eGameState == GAMESTATE.TRICK)
            ApplyPlayerMoveSpeed();
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        PlayerMoveVelocity = _context.ReadValue<Vector2>();
        FlipPlayerSprite(_context.ReadValue<Vector2>());
    }
    public void FlipPlayerSprite(Vector2 _vec)
    {
        if (_vec.x > 0)
            PlayerSpriteRenderer.flipX = false;
        else if(_vec.x < 0)
            PlayerSpriteRenderer.flipX = true;
    }

    public void ApplyPlayerMoveSpeed()
    {
        PlayerRigidbody2D.velocity = PlayerMoveVelocity * playerMoveSpeed;
    }
    public void OnPrank(InputAction.CallbackContext _context)
    {
        if(_context.started && GameManager.Instance.eGameState == GAMESTATE.TRICK)
        {
            OnPrankEvent?.Invoke();
        }
    }
}
