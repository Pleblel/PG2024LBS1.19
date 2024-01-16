using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    private WaveControl waveSpawner;
    public float hp;
    public GameObject gore;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveControl>();
    }

    //Pelle
    //Startar dmg funktion
    public void damageCall(float damage)
    {
        StartCoroutine(TakeDamage(damage));
    }
    //skade funktion
    IEnumerator TakeDamage(float damage)
    {
        //skadan
        hp -= damage;
        if(damage == 100)
        {
            //timing för blixt skada
            yield return new WaitForSecondsRealtime(0.3f);
        }
        //Fiende död koden
        if (hp <= 0)
        {
            Instantiate(gore, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            waveSpawner.OnEnemyDeath();
        }
    }
}
