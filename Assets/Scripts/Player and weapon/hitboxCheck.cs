using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class hitboxCheck : MonoBehaviour
{
    public float damage;
    public GameObject weap;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enemy = col.gameObject;
        enemyHP enemyComponent = enemy.GetComponent<enemyHP>();
        wall wallComponent = enemy.GetComponent<wall>();
        weapon spell = weap.GetComponent<weapon>();
        Debug.Log(spell.spells);
        if (enemyComponent != null)
        {
            if (spell.spells == 0)
            {
                damage = 80;
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
                damage = 190;
            }
            if (spell.spells == 3)
            {
                damage = 150;
            }
            enemyComponent.damageCall(damage);
        }
        if (wallComponent != null)
        {
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

    }
    private void Update()
    {

    }
}
