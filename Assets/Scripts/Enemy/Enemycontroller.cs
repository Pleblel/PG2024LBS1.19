using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public GameObject playerCont;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        // Gets SpriteRenderer component of gameObject. - Elm
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Finds player position relative to the gameObject - Elm
        Vector2 pos = playerCont.transform.position - gameObject.transform.position;

        // Flip the sprite depending on whether the enemy is to the left or right of the Player. - Elm (med kodhjälp från Pelle)
        if (pos.x > 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
