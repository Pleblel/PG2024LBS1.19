using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHardController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Plays the "EnemyHard.anim" file on the sprite when the Enemy is spawned. Due to the enemy never stopping, an idle animation is not needed and the animation never stops. - Elm
        GetComponent<Animator>().Play("EnemyHard");
    }
}
