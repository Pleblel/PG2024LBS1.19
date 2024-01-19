using UnityEngine;

public class lazarhitbox : MonoBehaviour
{
    //pelle
    public int dmg;
    void OnTriggerEnter2D(Collider2D col)
    {
        //kollor om det är spelare och skadar
        GameObject player = col.gameObject;
        playerMove playerComp = player.GetComponent<playerMove>();
        if (playerComp != null)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }
}
