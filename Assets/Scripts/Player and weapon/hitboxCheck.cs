using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class hitboxCheck : MonoBehaviour
{

    //Pelle
    public GameObject weap;
    int damage;

    //checks collision and gives dmg
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enemy = col.gameObject;
        enemyHP enemyComponent = enemy.GetComponent<enemyHP>();
        wall wallComponent = enemy.GetComponent<wall>();
        weapon spell = weap.GetComponent<weapon>();
        if (enemyComponent != null)
        {
            if (gameObject.tag == "water")
            {
                //förstör proj och skada
                damage = 80;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (gameObject.tag == "fire")
            {
                //förstör proj och skada
                damage = 5;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            if (gameObject.tag == "stone")
            {
                //skada
                damage = 150;
            }
            if (gameObject.tag == "lightning")
            {
                //förstör proj och skada
                damage = 290;
                Destroy(gameObject);
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
