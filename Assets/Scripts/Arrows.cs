using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    //setting up variables
    private Transform waypoint1;
    private float speed = 5f;


    private void Start()
    {
        //transform values of waypoint to destroy arrow objects
        waypoint1 = GameObject.Find("Arrow Waypoint").transform;
    }


    // Update is called once per frame
    void Update()
    {
        //this updates the arrow transform position to move towards the waypoint transform position
        transform.position = Vector2.MoveTowards(transform.position, waypoint1.transform.position, Time.deltaTime * speed);

        //Checks if the distance is close enough and destroys arrow at certain position
        if (Vector2.Distance(waypoint1.transform.position, transform.position) < .1f)
        {
            Destroy(gameObject);
        }

    }
       
}
