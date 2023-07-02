using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Sources for creating player controls: https://www.youtube.com/watch?v=HmXU4dZbaMw , https://www.youtube.com/watch?v=whzomFgjT50&list=LL&index=1, https://www.youtube.com/watch?v=LNLVOjbrQj4

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public PlayerInputActions playerControls;
    public Camera cam;
    Vector2 moveDirection = Vector2.zero;
    Vector2 aimDirection = Vector2.zero;
    Vector2 aimDirectionInGame = Vector2.zero;
    private InputAction move;
    private InputAction aim;
    

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        aim = playerControls.Player.Look;
        aim.Enable();
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        aim.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Use only for key inputs

        moveDirection = move.ReadValue<Vector2>();
        aimDirection = aim.ReadValue<Vector2>();
        aimDirectionInGame = cam.ScreenToWorldPoint(aimDirection);

        //animator.SetFloat("Horizontal", moveDirection.x);
        //animator.SetFloat("Vertical", moveDirection.y);
        //animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // For updating the player character movement
        rigidBody.MovePosition(rigidBody.position + moveDirection * movementSpeed * Time.fixedDeltaTime);


        // For updating the look direction

        Vector2 lookDirection = aimDirectionInGame - rigidBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;

    }

}
