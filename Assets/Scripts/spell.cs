using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class spell : MonoBehaviour
{
    public Rigidbody2D rb;
    public float mSpeed1;
    public float mSpeed2;
    public float mSpeed3;
    public GameObject weap;
    void Start()
    {
        weapon multSpl = weap.GetComponent<weapon>();
        if (multSpl.spells == 0)
        {
            rb.AddRelativeForce(new Vector2(0.01f * mSpeed1, 0));

        }
        if (multSpl.spells == 1)
        {
            rb.AddRelativeForce(new Vector2(0.01f * mSpeed2, 0));
        }
        if (multSpl.spells == 2)
        {
            rb.AddRelativeForce(new Vector2(0.01f * mSpeed3, 0));
        }
        if (multSpl.spells == 3)
        {
            
        }
    }
    public void Update()
    {
        weapon multSpl = weap.GetComponent<weapon>();
        if (multSpl.spells == 1)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

}

