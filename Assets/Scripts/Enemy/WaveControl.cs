using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    [SerializeField] private float countdown;

    public static bool start = false;

    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;

    public int currentWaveIndex = 0;

    private bool readyToCountDown;

    // Start is called once
    private void Start()
    {
        readyToCountDown = true;

            for (int i = 0; i < waves.Length; i++)
            {
                waves[i].enemiesLeft = waves[i].enemies.Length;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveIndex >= waves.Length && start)
        {
            Debug.Log("You survived every wave!");
            return;
        }

        if (readyToCountDown == true && start)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0 && start)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        if (waves[currentWaveIndex].enemiesLeft == 0 && start)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                // ring johan first thing på måndag
                enemyHP enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);

                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }
}

[System.Serializable]
public class Wave
{
    public enemyHP[] enemies;
    public float timeToNextWave;
    public float timeToNextEnemy;
    [HideInInspector] public int enemiesLeft;
}
