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

    [Header("Movement")]
    private Vector2 moveDirection;
    private float speed;
    public float walkSpeed;
    public float runSpeed;
    public float jumpImpulse;
    public LayerMask canJumpLayerMask;
    private bool canMove = true;
    private bool isMove = false;
    private bool isJumpPressed = false;

    [Header("Look")]
    private Vector2 mouseDelta;
    public Transform cameraContainer;
    public float maxXRotLook;
    public float minXRotLook;
    private float camCurXRot;
    public float lookSensitivity;
    public bool canLook = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        speed = walkSpeed;
        SetCursor();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            Look();
        }
    }

    private void Look()
    {
        CameraLook();
    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXRotLook, maxXRotLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
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

    private void Jump()
    {
        if (isJumpPressed && CanJump())
        {
            _rigidbody.AddForce(transform.up * jumpImpulse, ForceMode.Impulse);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && canMove)
        {
            isJumpPressed = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            isJumpPressed = false;
        }
    }

    private bool CanJump()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.1f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.1f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.1f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.1f) + (transform.up * 0.1f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, canJumpLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    
    public void SetCursor()
    {
        if (canLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
