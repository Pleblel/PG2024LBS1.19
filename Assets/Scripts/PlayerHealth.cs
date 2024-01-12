using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    int currenthealth;


    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage(20);
        }
    }

    // Call this method to apply damage to the attached gameObject
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);

        PlayerDeath();
    }

    void PlayerDeath()
    {
        //Kill animation of some sort

        //Disable the player.
    }
}


