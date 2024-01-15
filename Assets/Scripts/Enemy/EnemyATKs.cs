using System.Collections;
using System.Collections.Generic;
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
        timer += Time.deltaTime;
        Vector2 newPlayerPos = Player.transform.position - gameObject.transform.position;
        if (Mathf.Abs(newPlayerPos.x) < 1.8f && Mathf.Abs(newPlayerPos.y) < 1.5f && timer > 2)
        {
            attackPoint.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
            enemyAttack();
            timer = 0;
        }
    }

    void enemyAttack()
    {
        // Play an attack animation.
        

        // Detect enemies in range of attack.
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        // Damage them.
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }
    }
}
