using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables for Rigidbody
    public Rigidbody2D myRigidbody;

    // Serialized fields for movement and speed
    [SerializeField] private float movementSpeed = 3.0f;
    [SerializeField] private float jumpPower = 16f;
    [SerializeField] private float runSpeed = 8f;

    // Private variables for movement control
    private Vector2 movement;
    private float horizontal;
    private bool isFacingRight = true;
    private bool flipped;

    // Animator for player animations
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle Input for movement and jumping
        horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontal, 0).normalized;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * movementSpeed));

        // Flip character based on movement direction
        if (horizontal < 0)
        {
            flipped = true;
        }
        else if (horizontal > 0)
        {
            flipped = false;
        }
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

        // Handle Jumping - allows jumping without ground check
        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower);
        }
    }

    // FixedUpdate is called at fixed intervals (good for physics updates)
    private void FixedUpdate()
    {
        // Horizontal movement applied with Rigidbody
        myRigidbody.velocity = new Vector2(horizontal * runSpeed, myRigidbody.velocity.y);
    }

    // Flip character based on movement direction
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;  // Flip the character on the X axis
            transform.localScale = localScale;
        }
    }
}
