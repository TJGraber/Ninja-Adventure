using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 movementDirection;

    readonly int moveX = Animator.StringToHash("moveX");
    readonly int moveY = Animator.StringToHash("moveY");
    readonly int isMoving = Animator.StringToHash("isMoving");

    PlayerActions actions;
    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            anim.SetBool(isMoving, false);
            return;
        }

        anim.SetBool(isMoving, true);
        anim.SetFloat(moveX, movementDirection.x);
        anim.SetFloat(moveY, movementDirection.y);
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
