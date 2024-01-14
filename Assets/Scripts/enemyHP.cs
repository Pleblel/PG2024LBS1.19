using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    private WaveControl waveSpawner;

    public float hp;

    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveControl>();
    }

    public void damageCall(float damage)
    {
        StartCoroutine(TakeDamage(damage));
    }
    IEnumerator TakeDamage(float damage)
    {
        hp -= damage;
        if(damage == 100)
        {
            yield return new WaitForSecondsRealtime(0.3f);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);

            waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
        }
    }
}
