using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement: MonoBehaviour
{
    public Animator animator;
    private bool isGrounded;
    public Rigidbody2D rb;
    public float runningSpeed;
    public float jumpForce;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    [Header("Dash Mechanics")]
    public float dashSpeed = 10;
    public float totalDashTime = 0.5f;
    public float dashCoolDown = 0.5f;
    private float dashTimer;
    public float dashCoolDownTimer;
    private bool isDashing = false;
    public float currentSpeed;
    private float Acceleration = 1;//How fast will object reach a maximum speed
    private float Deceleration  = 1;//How fast will object reach a speed of 0
    [Header("Echoes")]
    public GameObject echoRight;
    public GameObject echoLeft;
    public float startTimeSpawns = 0.2f;
    private float timeBetweenEchoSpawns;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = totalDashTime;
        dashCoolDownTimer = dashCoolDown;
        currentSpeed = runningSpeed;
        Acceleration = totalDashTime / 2;
        Deceleration = totalDashTime / 2;
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
        
        //Handles dashing functionality 
        HandleDash();
    }

    private void HandleDash()
    {
        //Cooldown timer for dash
        if (!isDashing && dashTimer <= 0 && dashCoolDownTimer > 0)
        {
            dashCoolDownTimer -= Time.deltaTime;
        }

        //Resets dash functionality when cooldown timer is depleted
        else if (dashCoolDownTimer <= 0)
        {
            dashTimer = totalDashTime;
            dashCoolDownTimer = dashCoolDown;
        }

        //Resets dashing back to normal movement speed
        else if (dashTimer <= 0 && !Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDashing = false;
            //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed, rb.velocity.y);
            currentSpeed = runningSpeed;
        }
        
        //Dashing logic
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isDashing = true;
                //Handles dashes in the right direction
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    //Checks if switching directions
                    if (currentSpeed<0)
                    {
                        currentSpeed = runningSpeed;
                    }
                    //Acceleration Logic
                    if (currentSpeed > -dashSpeed)
                    {
                        currentSpeed = currentSpeed + (Acceleration * Time.deltaTime);
                    }
                    if(currentSpeed < -Deceleration * Time.deltaTime)
                    {
                        currentSpeed = currentSpeed + (Deceleration* Time.deltaTime);
                    }
                    dashTimer -= Time.deltaTime;
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * dashSpeed, rb.velocity.y);
                    SpawnEcho(echoRight);
                }
                
                //Handles dashes in the left direction
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    //Checks if switching directions
                    if (currentSpeed>0)
                    {
                        currentSpeed = -runningSpeed;
                    }
                    //Acceleration logic
                    if (currentSpeed < dashSpeed)
                    {
                        currentSpeed = currentSpeed - (Acceleration * Time.deltaTime);
                    }
                    if(currentSpeed > Deceleration*Time.deltaTime)
                    {
                        currentSpeed = currentSpeed - (Deceleration*Time.deltaTime);
                    }
                    dashTimer -= Time.deltaTime;
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * dashSpeed, rb.velocity.y);
                    SpawnEcho(echoLeft);
                }
            }
        }
    }

    /*
     * [Noah] echo spawner, this is here for dash testing purposes, along with the prefabs for the echos.
     * If this were to be permanently added, this should be separated out to another script to be reused 
     */
    private void SpawnEcho(GameObject echo)
    {
        if (timeBetweenEchoSpawns <= 0)
        {
            GameObject echoInstance = Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(echoInstance, 0.5f);
            timeBetweenEchoSpawns = startTimeSpawns;
        }
        else
        {
            timeBetweenEchoSpawns -= Time.deltaTime;
        }
    }
}
