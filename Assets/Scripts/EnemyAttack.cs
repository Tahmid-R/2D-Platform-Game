using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //function requires a layer mask to check if player is in attack range
    public LayerMask player;

    //getting attack position and setting its range
    public Transform attackPos;
    public float attackRange;
    

    public void Attack()
    {

        //returns the player collider that is overlapping in the circle (the attack position and range)
        Collider2D col = Physics2D.OverlapCircle(attackPos.position, attackRange, player);

        //if it is not empty then the player collider has overlapped in attack range and will respawn
        if (col != null && col.gameObject.GetComponent<CollisionDetector>().touched == false)
        {
            StartCoroutine(col.GetComponent<CollisionDetector>().Respawn());

        }
           
    }

    //visualises the attack range in scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
