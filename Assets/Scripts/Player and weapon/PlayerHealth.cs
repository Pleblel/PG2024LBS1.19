using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioClip DMGSFX;
    public int MaxHealth = 100;
    public float currenthealth;
    PlayerDeath playerdeath;
    public HealthBar healthbar;
    private bool playerNotDead = false;
    private float regenTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        regenTimer -= Time.deltaTime;

        // Slow health regen (2HP/s). - Elm
        if (regenTimer <= 0)
        {
            currenthealth += 2 * Time.deltaTime;
            regenTimer = 0;
        }
    }

    // Call this method to apply damage to the attached gameObject - Lucas
    public void TakeDamage(int damage)
    {
        //DMG Sound FX
        SoundFXManager.instance.PlaySoundFXclip(DMGSFX, transform, 1f);

        regenTimer = 3;

        // Removes health if damaged. - Lucas
        currenthealth -= damage;

        // Updates healthbar. - Elm
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


