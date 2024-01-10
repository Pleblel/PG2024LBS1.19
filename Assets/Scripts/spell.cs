using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public Rigidbody2D rb;
    public float mSpeed;
    void Start()
    {
        rb.AddRelativeForce(new Vector2(0.01f * mSpeed,0));
    }
}
