using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //variables for boss movement
    public float speed = 3f;
    public Transform player;
    Rigidbody2D rb;

    public float attackRange = 3f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //player position needed for boss to follow
        player = GameObject.FindGameObjectWithTag("player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        Die();
    }

    void FollowPlayer()
    {
        if (!player)
        {
            return;
        }

        FlipBoss();
        RageMode();

        //new position of boss based on player position
        Vector2 newPos = Vector2.MoveTowards(rb.position, new Vector2(player.position.x, rb.position.y), (speed * Time.fixedDeltaTime));

        
        rb.MovePosition(newPos);

        //checks if distance of player is within enemy attack range
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            anim.SetTrigger("Attack");
        }
    }

    void FlipBoss()
    {
        //flips boss sprite if player is left or right of it
        if(transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }

        else if(transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    void Die()
    {
        if (gameObject.GetComponent<HealthBar>().health == 0)
        {
            Destroy(gameObject);
        }
    }

    
    void RageMode()
    {
        //increases boss movement speed once health is below 50
        if (gameObject.GetComponent<HealthBar>().health < 50)
        {
            speed = 5;
        }
    }
}
