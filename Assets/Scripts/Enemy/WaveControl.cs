using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class WaveControl : MonoBehaviour
{
    [SerializeField] private float countdown;

    public static bool start = false;

    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;

    public int currentWaveIndex = 0;

    private bool readyToCountDown;

    float countdown2 = 0;
    public float Radius;
    Transform position;

    public Vector2 pos1;
    public Vector2 pos2;
    public Vector2 pos3;
    public Vector2 pos4;

    private Vector2 pos;
    private Vector2 rand;
    private bool playOnce = true;

    public Transform EnemyParent;

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
        countdown2 += Time.deltaTime;

        // After 0.2 seconds have passed:
        if (countdown2 >= 0.2f || playOnce)
        {
            int randomInt1 = Random.Range(0, 3);

            if (randomInt1 == 0)
            {
                pos = pos1;
            }
            else if (randomInt1 == 1)
            {
                pos = pos2;
            }
            else if (randomInt1 == 2)
            {
                pos = pos3;
            }
            else if (randomInt1 == 3)
            {
                pos = pos4;
            }

            rand = pos + Random.insideUnitCircle * Radius;
            countdown2 = 0;
            playOnce = false;
        }

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
                // ring johan first thing p� m�ndag
                enemyHP enemy = Instantiate(waves[currentWaveIndex].enemies[i], new Vector3 (rand.x, rand.y, 0), Quaternion.identity, EnemyParent);
                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }


    public void OnEnemyDeath()
    {
        waves[currentWaveIndex].enemiesLeft--;
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
