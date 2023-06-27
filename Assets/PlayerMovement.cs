using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Sources for creating player controls: https://www.youtube.com/watch?v=HmXU4dZbaMw , https://www.youtube.com/watch?v=whzomFgjT50&list=LL&index=1

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public PlayerInputActions playerControls;
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Use only for key inputs

        moveDirection = move.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // For updating the player character movement
        rigidBody.MovePosition(rigidBody.position + moveDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
