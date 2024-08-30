using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //variables for camera following player position
    Transform player;

    [SerializeField]
    private float minX, maxX, maxY;
    private Vector3 temp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();   
    }

    void CameraFollow()
    {

        if (!player)
        {
            return;
        }

        //set variable to camera position
        temp = transform.position;
        temp.x = player.position.x;

        //follows player y movement at certain threshold
        if(player.position.y > maxY)
        {
            temp.y = player.position.y;
        }
        else
        {
            //default y position of camera
            temp.y = 2.4f;
        }
       
        //stops following player x movement at certain boundary 
        if (temp.x < minX)
        {
            temp.x = minX;
        }
        else if(temp.x > maxX)
        {
            temp.x = maxX;
        }

        //sets camera position to temp position which follows player position
        transform.position = temp;
    }
}
