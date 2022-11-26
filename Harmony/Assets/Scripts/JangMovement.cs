using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JangMovement : MonoBehaviour
{
    [SerializeField] Transform groundCheckCollider;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]private float moveSpeed;
    [SerializeField] private float jumpHeight;
    private float gravity;
    private Rigidbody2D body;
    [SerializeField] bool isGrounded = false;
    const float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    bool isWalking;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGrownd();
        movement();
        animUbdate();

        


    }
    void movement()
    {
        //right and left
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);

        //changing sides
        if (body.velocity.x > 0.5)
        {
            transform.localScale = new Vector3(0.4415086f, 0.4415086f, 1f);
            isWalking = true;
        }
        else if (body.velocity.x < -0.5)
        {
            transform.localScale = new Vector3(-0.4415086f, 0.4415086f, 1f);
            isWalking = true;
        }
        else {
            isWalking = false;
        }
        

        //jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Vector2 jump = new Vector2(Input.GetAxis("Horizontal"), jumpHeight);

            body.AddForce(jump);
        }
    }

    void isOnGrownd()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        
        if (colliders.Length>0)
        {
            isGrounded = true;
        }

    }

    void animUbdate()
    {
        anim.SetFloat("yVelocity", body.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWalking", isWalking);
    }
}
