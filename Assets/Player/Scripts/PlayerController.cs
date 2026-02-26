using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input Actions
    private ProjectActions actionSystem;
    private InputAction move;
    private InputAction jump;
    private InputAction dash;

    // Movement
    private int direction;
    private Rigidbody2D rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float movementAcceleration = 8f;
    private float currentSpeed = 0f;
    // Terminal Velocity
    [SerializeField] private float TerminalSpeed = 15f;
    private float FallMultiplier = 2.5f;

    // Jump
    private float GroundRaycastDistance = 0.52f;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] float JumpForce = 3f;
    private bool Jumping = false;

    private void Awake()
    {
        actionSystem = new ProjectActions();
    }
    private void OnEnable()
    {
        move = actionSystem.Player.Move;
        jump = actionSystem.Player.Jump;
        dash = actionSystem.Player.Dash;

        move.Enable();
        jump.Enable();
        dash.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        dash.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        HeavyFall();
    }

    private void Move()
    {
        // 0 means there's no movement whereas -1 and 1 means there is movement in a direction.
        float movement = move.ReadValue<float>();
        SetDirection(movement);

        float speed_ref = 0f;

        if (movement != 0)
            // This happens when we move
            currentSpeed = Mathf.SmoothDamp(currentSpeed, movementSpeed, ref speed_ref, movementAcceleration * Time.fixedDeltaTime);

        else
            // This happens when we let go of move.
            currentSpeed = Mathf.SmoothDamp(currentSpeed, 0, ref speed_ref, movementAcceleration * Time.fixedDeltaTime);

        // As the speed approaches zero on slowdown, set it to zero eventually.
        if (currentSpeed <= 0.005f) currentSpeed = 0f;

        // Translate towards the direction we are moving (or the direction we were previously moving towards) at the assigned speed.
        rb.linearVelocity = new Vector2(direction * currentSpeed, rb.linearVelocity.y);
    }

    private void SetDirection(float movement)
    {
        // If the input is 0 that means we are not moving so keep the direction as is.
        // If the input is 1 or -1 then we are moving and we want to change the way the player sprite is facing.
        float movementDir = RoundDirection(movement);

        // The direction is either set to the key that the player is currently holding or to the last key the player held.
        direction = (movementDir != 0) ? (int)movementDir : direction;
    }

    private int RoundDirection(float input)
    {
        // Although I am expecting the movement values to be -1, 0, or 1, this ensures that the behaviour of the sprite is as expected if the values span real numbers from -1 to 1.
        return (input > 0) ? (int)Math.Ceiling(input) : (input < 0) ? (int)Math.Floor(input) : 0;
    }
    private void HeavyFall()
    {
        // If linear velocity in the y direction is negative, add some extra gravity.
        // Make sure it is clamped to a terminal velocity.
        if (rb.linearVelocityY < 0f)
        {
            if (rb.linearVelocityY <= -TerminalSpeed) rb.linearVelocityY = -TerminalSpeed;
            else rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1f) * Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        float jumping = jump.ReadValue<float>();
        bool IsGrounded = isGrounded();

        if (jumping == 1)
        {

        }
        else
        {

        }
    }

    private bool isGrounded()
    {
        // return Physics2D.OverlapCircle(rb.transform.position, GroundRaycastDistance, GroundLayer);
        // Make this come out of the feet, not the body.
        return Physics2D.Raycast(rb.transform.position, Vector2.down, GroundRaycastDistance, GroundLayer);
    }

    private void PerformJump()
    {
        // Add the jump force here.
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        // Set the Jumping bool to true.
        Jumping = true;
        // Start the early bounce frame counter.
        // EarlyBounceFrameCounter = EarlyBounceFrameCount;
    }
}
