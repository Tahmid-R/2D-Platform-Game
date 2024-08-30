using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    private int lives;
    private int collectibles;
    [HideInInspector] public bool touched;

    [SerializeField]
    private Text lifeText;
    [SerializeField]
    private Text collectibleText;

    public AudioSource deathEffect;
    public AudioSource collectible;

    private Vector2 startPos;
  

    private void Start()
    {
        //stores the starting position of player for respawning
        startPos = transform.position;

        lives = 3;
        collectibles = 0;
        touched = false;
       
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checking collisions for outer bounds
        if (collision.gameObject.CompareTag("Bounds"))
        {
            StartCoroutine(Respawn());
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking collisions of traps
        if (collision.gameObject.CompareTag("Trap") && !touched){
            StartCoroutine(Respawn());

        }

        //checking collisions of collectibles and destroys upon collision
        if (collision.gameObject.CompareTag("Collectible"))
        {
            if (collectibles >= 10 && collectibles % 10 == 0)
            {
                lives += 1;
                lifeText.text = "Lives: " + lives.ToString();
            }
            collectible.Play();
            Destroy(collision.gameObject);

            //increments and updates collision counter text on screen
            collectibles++;
            collectibleText.text = "Collectibles: " + collectibles;
        }
    }

    public IEnumerator Respawn()
    {
        //upon collision this respawn function will run and decrease the lives
        if (lives <= 1)
        {
            Die();
        }
        lives -= 1;
        deathEffect.Play();
        lifeText.text = "Lives: " + lives.ToString();

        //respawns player to starting position
        transform.position = startPos;

        //brief ivincibility from traps and enemies after respawn
        touched = true;
        yield return new WaitForSeconds(2);
        touched = false;
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
