using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class hitboxCheck : MonoBehaviour
{
    float damage;
    public GameObject weap;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enemy = col.gameObject;
        enemyHP enemyComponent = enemy.GetComponent<enemyHP>();
        weapon spell = weap.GetComponent<weapon>();
        Debug.Log(spell.spells);
        if (enemyComponent != null)
        {
            if (spell.spells == 0)
            {
                damage = 20;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (spell.spells == 1)
            {
                damage = 1;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (spell.spells == 2)
            {
                damage = 30;
            }
            if (spell.spells == 3)
            {
                damage = 100;
            }
            enemyComponent.damageCall(damage);
        }

    }
    private void Update()
    {

    }
}
