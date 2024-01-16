using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    //Pelle
    public SpriteRenderer playerSprite;
    public SpriteRenderer sr;
    public GameObject player;
    public GameObject hand;
    void Update()
    {
        // kollar om mus �r h�ger eller v�nster
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //byter sida p� boken
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
