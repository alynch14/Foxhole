using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement: MonoBehaviour
{
    public Animator animator;
    private bool isGrounded;
    private bool isDashing = false;
    public Rigidbody2D rb;
    public float runningSpeed;
    public float jumpForce;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float dashSpeed = 10;
    private float dashTimer;
    public float totalDashTime = 0.5f;
    public float dashCoolDown = 0.5f;
    private float dashCoolDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = totalDashTime;
        dashCoolDownTimer = dashCoolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }

    private void Update()
    {
        //Move the rigidbody attached to the fox in the x and y directions
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        // If we are on the ground and space is pressed, jump
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        HandleDash();

    }

    private void HandleDash()
    {
        if (!isDashing && dashTimer <= 0 && dashCoolDownTimer > 0)
        {
            dashCoolDownTimer -= Time.deltaTime;
        }

        else if (dashCoolDownTimer <= 0)
        {
            dashTimer = totalDashTime;
            dashCoolDownTimer = dashCoolDown;
        }

        else if (dashTimer <= 0 && !Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDashing = false;
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed, rb.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isDashing = true;
                if (Input.GetKey(KeyCode.D))
                {
                    dashTimer -= Time.deltaTime;
                    rb.velocity = Vector2.right * dashSpeed;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    dashTimer -= Time.deltaTime;
                    rb.velocity = Vector2.left * dashSpeed;
                }
            }
        }
    }
}
