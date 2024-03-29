using System.Collections;
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
    public void damageCall(int damage, int spell)
    {
        StartCoroutine(TakeDamage(damage, spell));
    }
    //skade funktion
    IEnumerator TakeDamage(int damage, int spell)
    {
        //skadan
        hp -= damage;
        if(damage == 290)
        {
            //timing f�r blixt skada
            yield return new WaitForSecondsRealtime(0.3f);
        }
        //Fiende d�d koden
        if (hp <= 0)
        {
            if (spell != 4)
            {
                Instantiate(gore, gameObject.transform.position, Quaternion.identity);

            }
            Destroy(gameObject);

            // Tells WaveControl script to remove 1 from the waves[currentWaveIndex].enemiesLeft. - Elm
            waveSpawner.OnEnemyDeath();
        }
    }
}
