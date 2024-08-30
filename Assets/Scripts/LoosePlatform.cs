using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosePlatform : MonoBehaviour
{

    private GameObject boss;
    private Vector3 temp;

    private void Start()
    {
        boss = GameObject.Find("Boss");
        temp = transform.position;

        //hide platform until boss is destroyed
        transform.position = new Vector3(transform.position.x, 120, transform.position.z);
    }


    private void FixedUpdate()
    {
        if (!boss)
        {
            transform.position = temp;
        }
    }

    //similar to end game script
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when it collides with player the platform will destroy after brief period
        if (collision.gameObject.CompareTag("player"))
        {
            Invoke("DestroyPlatform", 0.2f);
        }
    }

    void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
