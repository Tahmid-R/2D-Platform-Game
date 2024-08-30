using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables for player movement
    public float speed = 10f;
    public float jump = 7f;
    private float movementX;
    Rigidbody2D rb;

    //booleans used for conditional checking movement
    private bool isJump;
    private bool isGrounded = true;

    public AudioSource jumpEffect;
    Animator anim;
   
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animate();
    }

    void Movement()
    {
        //platform neutral function, returns -1 for left and 1 for right
        movementX = Input.GetAxisRaw("Horizontal");

        isJump = Input.GetKeyDown(KeyCode.UpArrow);

        //updates player position X by 1 or -1
        transform.position += new Vector3(movementX, 0f, 0f) * (Time.deltaTime * speed);


        //avoids jumping in air
        if (isJump && isGrounded)
        {
            //adds force to player y position (jump force) 
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            jumpEffect.Play();

            anim.SetBool("Jump", true);

            //sets grounded to false since player in air
            isGrounded = false;
        }

    }

   
    void Animate()
    {
        //if player is moving left or right it will play run animation and flip player to facing direction
        if (movementX > 0)
        {
            anim.SetBool("Run", true);
            transform.localScale=new Vector3(3,3,1);

        }
        else if (movementX < 0)
        {
            anim.SetBool("Run", true);
            transform.localScale = new Vector3(-3, 3, 1);

        }
        else
        {
            anim.SetBool("Run", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //once player collides with ground it can jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jump", false);
            isGrounded = true;
        }

    }
}
