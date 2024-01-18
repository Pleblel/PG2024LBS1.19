using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public float currenthealth;
    PlayerDeath playerdeath;
    public HealthBar healthbar;
    private bool playerNotDead = false;
    [SerializeField] private AudioClip DMGSFX;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
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
        //plays Player dmg sfx
        SoundFXManager.instance.PlaySoundFXclip(DMGSFX, transform, 1f);

        // Removes health if damaged. - Lucas
        currenthealth -= damage;

        healthbar.SetHealth(currenthealth);

        // If the players health reaches 0, the player death method is called. - Elm
        if (currenthealth <= 0 && playerNotDead == false)
        {
            DeathOfPlayer();
            playerNotDead = true;
        }
    }

    // Gets called when player dies. - Elm
    public void DeathOfPlayer()
    {
        // Gets PlayerDeath script in the context. - Elm
        playerdeath = FindObjectOfType<PlayerDeath>();

        // Gets animation. - Elm
        StartCoroutine(playerdeath.PlayerDeathAnimation());

        // Disables player. - Elm
        gameObject.SetActive(false);
    }
}


