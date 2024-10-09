using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkManScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float Runspeed;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) == true)
        {
            myRigidbody.velocity = Vector2.left * Runspeed;
        }

        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            myRigidbody.velocity = Vector2.up * Runspeed;
        }

        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            myRigidbody.velocity = Vector2.right * Runspeed;
        }

        if (Input.GetKeyDown(KeyCode.S) == true)
        {
            myRigidbody.velocity = Vector2.down * Runspeed;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            transform.localScale = localScale;  
        }
    }
}
