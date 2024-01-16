using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class hitboxCheck : MonoBehaviour
{
    public float damage;
    public GameObject weap;

    //checks collision and gives dmg
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enemy = col.gameObject;
        //tar fiende
        enemyHP enemyComponent = enemy.GetComponent<enemyHP>();
        //tar vägg
        wall wallComponent = enemy.GetComponent<wall>();
        //tar vilken spell det är
        weapon spell = weap.GetComponent<weapon>();
        //kollar om det är en fiende
        if (enemyComponent != null)
        {
            if (spell.spells == 0)
            {
                //DMG VALUE WATER
                damage = 80;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (spell.spells == 1)
            {
                //DMG VALUE FIRE
                damage = 1;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (spell.spells == 2)
            {
                //DMG VALUE BOULDER
                damage = 60;
            }
            if (spell.spells == 3)
            {
                //DMG VALUE LIGHTNING
                damage = 150;
            }
            enemyComponent.damageCall(damage);
        }
        //kollar om den spell träffar vägg
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
