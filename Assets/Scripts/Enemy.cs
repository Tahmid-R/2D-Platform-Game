using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variables for enemy movement
    Rigidbody2D rb;
    public float minX, maxX;
    private float speed;

    public float attackRange = 3f;
    Transform player;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //enemy will be given random speed
        speed = -Random.Range(4, 10);
        rb = GetComponent<Rigidbody2D>();

        //getting player position
        player = GameObject.FindGameObjectWithTag("player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            return;
        }

        Movement();
        AnimateMovement();
       

    }

    void Movement()
    {
        //adds velocity to enemy sprite to allow movement
        rb.velocity = new Vector2(speed, rb.velocity.y);

        //specific boundaries set for enemy, flips sprite and sets new random speed
        if (transform.position.x < minX)
        {
            transform.localScale = new Vector3(-3, 3, 1);
            speed = Random.Range(4, 10);
        }
        else if (transform.position.x > maxX)
        {
            transform.localScale = new Vector3(3, 3, 1);
            speed = -Random.Range(4, 10);
        }
    }

    void AnimateMovement()
    {
        //checks if distance of player is within enemy attack range
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            //plays attack animation
            anim.SetTrigger("Attack");
        }
    }

    
}
