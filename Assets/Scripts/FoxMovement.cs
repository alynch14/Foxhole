using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement: MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private bool isGrounded = true;
    private Vector3 currentPosition;
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        Vector3 vertical = new Vector3();

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
