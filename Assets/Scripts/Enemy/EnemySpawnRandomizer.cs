using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnRandomizer : MonoBehaviour
{
    float countdown = 0;
    public float Radius;
    Transform position;

    public Vector2 pos1;
    public Vector2 pos2;
    public Vector2 pos3;
    public Vector2 pos4;

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;

        // After 0.2 seconds have passed:
        if (countdown >= 1)
        {
            int randomInt1 = Random.Range(0, 1);
            int randomInt2 = Random.Range(0, 1);

            if (randomInt1 == 0)
            {
                transform.position = pos1;
            } else if (randomInt1 == 1)
            {
                transform.position = pos2;
            }

            if (randomInt2 == 0)
            {
                transform.position = pos3;
            }
            else if (randomInt2 == 1)
            {
                transform.position = pos4;
            }

            Vector2 rand = Random.insideUnitCircle * Radius;
            transform.position = rand;
            countdown = 0;
        }
    }
}
