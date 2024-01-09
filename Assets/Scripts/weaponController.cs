using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;
    public GameObject player;
    public GameObject hand;
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (pos.x >= 0.5f)
        {
            sr.flipY = false;
        }
        else
        {
            sr.flipY = true;
        }   
    }
}
