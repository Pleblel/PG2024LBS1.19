using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    //Pelle
    private WaveControl waveSpawner;
    public float hp;
    public GameObject gore;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveControl>();
    }

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
        if(damage == 290)
        {
            //timing för blixt skada
            yield return new WaitForSecondsRealtime(0.3f);
        }
        //Fiende död koden
        if (hp <= 0)
        {
            Instantiate(gore, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

            // Tells WaveControl script to remove 1 from the waves[currentWaveIndex].enemiesLeft. - Elm
            waveSpawner.OnEnemyDeath();
        }
    }
}
