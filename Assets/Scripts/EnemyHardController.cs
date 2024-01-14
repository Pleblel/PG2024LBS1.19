using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHardController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("EnemyHard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
