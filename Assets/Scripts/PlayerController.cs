using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    private Vector2 moveDirection;
    private float speed;
    public float walkSpeed;
    public float RunSpeed;
    private bool canMove = true;
    private bool isMove = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        speed = walkSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveVector = transform.forward * moveDirection.y + transform.right * moveDirection.x;
        moveVector *= speed;
        moveVector.y = _rigidbody.velocity.y;
        _rigidbody.velocity = moveVector;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && canMove)
        {
            moveDirection = context.ReadValue<Vector2>();
            isMove = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveDirection = Vector2.zero;
            isMove = false;
        }
    }
}
