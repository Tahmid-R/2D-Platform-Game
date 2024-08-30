using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    
    void Start()
    { 
        StartCoroutine(ArrowSpawn());
        
    }

    
    IEnumerator ArrowSpawn()
    {
        //repeatedly runs and creates arrow objects
        while (true)
        {
            //will wait for random amount of seconds
            yield return new WaitForSeconds(Random.Range(1,5));

            //creates arrow object 
            Instantiate(arrow);

        }
    }
}
