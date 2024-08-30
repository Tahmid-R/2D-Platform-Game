using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //avoids repeated level completion audio 
    private bool end = false;
    public AudioSource levelComplete;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collides with chest it will move to next level 
        if (collision.gameObject.CompareTag("player") && (!end))
        {
            levelComplete.Play();

            //brief pause before moving to next level
            Invoke("NextLevel", 1f);
            end = true;
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
