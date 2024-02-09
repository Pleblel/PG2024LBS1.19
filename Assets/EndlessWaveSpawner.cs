using UnityEngine;

public class EndlessWaveSpawner : MonoBehaviour
{
    public float Radius;
    float countdown = 0;
    float countdown2 = 0;
    public Vector2 pos1;
    public Vector2 pos2;
    public Vector2 pos3;
    private Vector2 pos;
    private Vector2 rand;
    public GameObject enemyEasyObject;
    public GameObject enemyHardObject;
    public Transform EnemyParent;
    private bool playOnce = true;
    private void Update()
    {
        countdown += Time.deltaTime;
        countdown2 += Time.deltaTime;

        // After 0.2 seconds have passed or the script starts for the first time: Updates position of the spawnpoint for enemies. - Elm
        if (countdown >= 0.2f || playOnce)
        {
            // Updates variable "pos" (Spawn position of enemy) randomly between pos1 - pos3 with Random.Range() method. - Elm
            int randomInt1 = Random.Range(0, 2);

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

            // Creates a random position inside a UnitCircle at the coordinates of "pos". - Elm
            rand = pos + Random.insideUnitCircle * Radius;

            // Resets timer and start variable from menu scene. - Elm
            countdown = 0;
            playOnce = false;
        }

        // Generates random value between 0 and 4 - Elm
        int randomint2 = Random.Range(0, 5);

        // Spawns enemies depending on the generated random value above after 0.75s have passed since last spawn. The spawnrates stand at 40% for EnemyHard and 60% for EnemyEasy. - Elm
        if ((randomint2 == 0 && countdown2 > 0.75) || (randomint2 == 1 && countdown2 > 0.75))
        {
            Instantiate(enemyHardObject, pos, Quaternion.identity, EnemyParent);
            Debug.Log("Spawned EnemyHard at position" + pos);
            countdown2 = 0;
        } 
        else if (randomint2 != 0 && randomint2 != 1 && countdown2 > 0.75)
        {
            Instantiate(enemyEasyObject, pos, Quaternion.identity, EnemyParent);
            Debug.Log("Spawned EnemyEasy at position " + pos);
            countdown2 = 0;
        }

        
    }
}