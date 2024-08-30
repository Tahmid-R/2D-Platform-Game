using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //cooldown period for attacking
    public float startAttack;
    private float cooldownAttack;

    //variables for attacking enemies
    public LayerMask enemy;
    public Transform attackPos;
    public float attackRange;

    public AudioSource hitEffect;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(cooldownAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                anim.SetTrigger("Attack");

                //returns list of enemy colliders that overlap within attack circle of player
                Collider2D[] col = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                

                for (int i=0;i< col.Length;i++)
                {
                    //goes through collider array and destroys enemy sprite
                    if (col[i].gameObject.CompareTag("Enemy"))
                    {
                        hitEffect.Play();
                        Destroy(col[i].gameObject);
                    }
                    //goes through collider array and reduces boss health
                    else if (col[i].gameObject.CompareTag("Boss"))
                    {
                        col[i].GetComponent<HealthBar>().Damage();
                    }
                    
                    
                }

                
                cooldownAttack = startAttack;
            }
        }
        else
        {
            //decrease cooldown period
            cooldownAttack -= Time.deltaTime;
        }
    }

    //visualising attack range in scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
