using UnityEngine;

public class EnemyATKs : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public int enemyDamage;
    public float timer;

    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        // Cooldown timer for attacking. (it is set to 2 below in the If statement.) - Elm
        timer += Time.deltaTime;

        // Get player position. - Elm
        Vector2 newPlayerPos = Player.transform.position - gameObject.transform.position;

        // If player is within range, update attackpoint of enemy to player and call the attack method. - Elm
        if (Mathf.Abs(newPlayerPos.x) < 1.8f && Mathf.Abs(newPlayerPos.y) < 1.5f && timer > 2)
        {
            attackPoint.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
            enemyAttack();
            timer = 0;
        }
    }

    void enemyAttack()
    {
        // Play an attack animation. (planned) - Elm


        // Detect if Player is in range of attack. - Elm
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        // Damage the Player by calling TakeDamage() method. - Elm
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
    }
}
