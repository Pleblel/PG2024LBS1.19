using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustRot : MonoBehaviour
{
    //Pelle
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        //roterar dust effekten
        GetComponent<ParticleSystem>();
        if (moveX == -1)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }
}
