using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazarhitbox : MonoBehaviour
{
    public int dmg;
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject player = col.gameObject;
        playerMove playerComp = player.GetComponent<playerMove>();
        if (playerComp != null)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }
}
