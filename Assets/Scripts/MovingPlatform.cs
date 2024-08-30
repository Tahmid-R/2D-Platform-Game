using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //waypoints to move back and forth
    public GameObject waypoint1, waypoint2;

    public float speed = 2f;

    //used to distinguish waypoint
    private int reachedWayPoint = -1;


    // Update is called once per frame
    void Update()
    {
        //once platform reaches bottom/left waypoint the distance changes to -1 and moves to the top/right waypoint
        if(reachedWayPoint == -1)
        {
            //updates platform position to move towards waypoint position
            transform.position = Vector2.MoveTowards(transform.position, waypoint1.transform.position, Time.deltaTime * speed);

            //checks if platform has reached the waypoint
            if (Vector2.Distance(waypoint1.transform.position, transform.position) < .1f)
            {
                reachedWayPoint = 1;
            }

        }
        if (reachedWayPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint2.transform.position, Time.deltaTime * speed);
            if (Vector2.Distance(waypoint2.transform.position, transform.position) < .1f)
            {
                reachedWayPoint = -1;
            }

        }


    }
}
