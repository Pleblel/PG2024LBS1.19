using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public SpriteRenderer sr;
    public GameObject player;
    public GameObject hand;
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (pos.x >= 0.5f)
        {
            sr.flipY = false;
            playerSprite.flipX = false;
        }
        else
        {
            sr.flipY = true;
            playerSprite.flipX = true;
        }   
    }
}
