using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 movementDirection;

    PlayerActions actions;
    Rigidbody2D rb;
    PlayerAnimations animations;

    private void Awake()
    {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        animations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ReadMovement()
    {
        movementDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        if(movementDirection == Vector2.zero)
        {
            animations.HandleMoveBoolAnimation(false);
            return;
        }

        animations.HandleMoveBoolAnimation(true);
        animations.HandleMovingAnimation(movementDirection);
    }

    void Move()
    {
        rb.MovePosition(rb.position + movementDirection * (movementSpeed * Time.deltaTime));
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
