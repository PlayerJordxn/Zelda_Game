using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //Component Variables
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundedLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool facingRight;
    public bool isFiring;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 100;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }

        if (!groundCheck)
        {
            Debug.Log("GroundCheck does not exist, please set a transform value for groundcheck");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundedLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);

        }

        if (Input.GetButtonDown("Fire1"))
        {
            isFiring = true;
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
        }

        rb.velocity = new Vector2(horizontalValue * speed, rb.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(horizontalValue));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFiring", isFiring);


    }


}
