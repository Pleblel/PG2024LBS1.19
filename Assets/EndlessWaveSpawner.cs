using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EndlessWaveSpawner : MonoBehaviour
{
    public float Radius;
    float countdown = 0;
    float countdown2 = 0;
    public Vector2 pos1;
    public Vector2 pos2;
    public Vector2 pos3;
    public Vector2 pos4;
    private Vector2 pos;
    private Vector2 rand;
    private bool playOnce = true;
    private void Update()
    {
        countdown += Time.deltaTime;
        countdown2 += Time.deltaTime;

        // After 0.2 seconds have passed or the script starts for the first time: Updates position of the spawnpoint for enemies. - Elm
        if (countdown >= 0.2f || playOnce)
        {
            // Updates variable "pos" (Spawn position of enemy) randomly between pos1 - pos4 with Random.Range() method. - Elm
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

            // Creates a random position inside a UnitCircle at the coordinates of "pos". - Elm
            rand = pos + Random.insideUnitCircle * Radius;

            // Resets timer and start variable from menu scene. - Elm
            countdown = 0;
            playOnce = false;
        }

        int randomint2 = Random.Range(0, 6);

        if (randomint2 == 0)
        {
            
        } else if (randomint2 != 0)
        {

        }
    }
}