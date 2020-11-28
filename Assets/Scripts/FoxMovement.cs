using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement: MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private bool isGrounded = true;
    private Vector3 currentPosition;
    private int counter = 0;
    public BoxCollider2D ground;


    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        Vector3 vertical = new Vector3();

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            vertical = Jump();
            Debug.Log("Vertical vector: " + vertical.ToString());
        }

        transform.position = transform.position + (horizontal + vertical) * 3 * Time.deltaTime;
    }

    Vector3 Jump()
    {
        float verticalMagnitude = 0;

        if (counter < 5)
        {
            counter++;
            Debug.Log("Counter: " + counter);
            verticalMagnitude += 1.0f * counter;
        } else
        {
            counter = 0;
            isGrounded = false;
        }

        return new Vector3(0.0f, verticalMagnitude, 0.0f);
    }
}
