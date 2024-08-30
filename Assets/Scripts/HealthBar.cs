using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // green health bar image in boss level
    public Image healthBar;

    //boss health
    public float health = 100f;

    private void Update()
    {
        //print(health);
    }


    public void Damage()
    {
        //when boss takes damage in PlayerAttack script, health is decreased
        health -= 10;

        // green health bar fill amount is updated based on health 
        healthBar.fillAmount = health / 100f;
    }
}
