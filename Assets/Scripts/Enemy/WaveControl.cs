using System.Collections;
using UnityEngine;

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
        // Starts the countdown to the next wave. 0 by default, so wave 1 starts immediately. - Elm
        readyToCountDown = true;

            // 
            for (int i = 0; i < waves.Length; i++)
            {
                waves[i].enemiesLeft = waves[i].enemies.Length;
            }
    }

    // Update is called once per frame
    void Update()
    {
        countdown2 += Time.deltaTime;

        // After 0.2 seconds have passed or the script starts for the first time: Updates position of the spawnpoint for enemies. - Elm
        if (countdown2 >= 0.2f || playOnce)
        {
            // Updates variable "pos" (Spawn position of enemy) randomly between pos1 - pos3 with Random.Range() method. - Elm
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
                // The rangemax is exclusive in the Random class, which was initially skipping one spot of spawning and was a bug, but now it's an intended feature. - Elm
                pos = pos4;
            }

            // Creates a random position inside a UnitCircle at the coordinates of "pos". - Elm
            rand = pos + Random.insideUnitCircle * Radius;

            // Resets timer and start variable from menu scene. - Elm
            countdown2 = 0;
            playOnce = false;
        }

        // Used to signify the end of the last wave. Also stops the WaveSpawner from functioning further. - Elm
        if (currentWaveIndex >= waves.Length && start)
        {
            Debug.Log("You survived every wave!");
            return;
        }

        // Counts down every second when the wavespawner script starts. - Elm
        if (readyToCountDown == true && start)
        {
            countdown -= Time.deltaTime;
        }

        // Stops the countdown and resets it to the time between this wave and the next. Starts the next wave. - Elm
        if (countdown <= 0 && start)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        // If all the enemies have died, restarts the process again. - Elm
        if (waves[currentWaveIndex].enemiesLeft == 0 && start)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }

    // Spawns enemies based on the currentWaveIndex. - Elm
    private IEnumerator SpawnWave()
    {
        // Stops if it is the last wave. - Elm
        if (currentWaveIndex < waves.Length)
        {
            // Clones for the amount of enemies inside the specified Wave. - Elm
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                // Clones already existing (offscreen) enemies with updated positions and parents. - Elm
                enemyHP enemy = Instantiate(waves[currentWaveIndex].enemies[i], new Vector3 (rand.x, rand.y, 0), Quaternion.identity, EnemyParent);

                // Waits for 0.2 seconds. - Elm
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }

    // Called when an enemy dies. - Elm
    public void OnEnemyDeath()
    {
        // On enemy death, 1 is removed from the .enemiesLeft variable. - Elm
        waves[currentWaveIndex].enemiesLeft--;
    }
}

[System.Serializable]
public class Wave
{
    // Array of specified enemies that contain the enemyHP script. - Elm
    public enemyHP[] enemies;

    public float timeToNextWave;
    public float timeToNextEnemy;
    [HideInInspector] public int enemiesLeft;
}
