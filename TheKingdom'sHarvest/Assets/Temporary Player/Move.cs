using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator Peasant;
    Vector2 movement;
    bool facingRight = false;  // Initial stance of the character is facing left

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animation
         if (movement.x != 0 || movement.y != 0)
        {
            Peasant.SetBool("IsWalking", true);
        }
        else
        {
            Peasant.SetBool("IsWalking", false);
        }
        

        // Flip character
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
