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

        // Flips the sprite of the gameObject depending on whether the player is to the left or right. - Elm
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
