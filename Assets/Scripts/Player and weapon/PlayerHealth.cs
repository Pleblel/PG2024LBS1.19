using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    public float currenthealth;
    PlayerDeath playerdeath;


    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        playerdeath = GetComponent<PlayerDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        // Slow health regen. - Lucas
        currenthealth += Time.deltaTime / 100;
    }

    // Call this method to apply damage to the attached gameObject - Lucas
    public void TakeDamage(int damage)
    {
        // Removes health if damaged. - Lucas
        currenthealth -= damage;

        healthbar.SetHealth(currenthealth);

        // If the players health reaches 0, the player dies. - Elm
        if (currenthealth <= 0)
        {
            DeathOfPlayer();
        }
    }

    // Gets called when player dies. - Elm
    public void DeathOfPlayer()
    {
        // Gets animation. - Elm
        playerdeath.PlayerDeathAnimation();

        // Disables player. - Elm
        gameObject.SetActive(false);
    }
}


