using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class EndlessTimer : MonoBehaviour
{
    float timer;
    public void Update()
    {
        timer += Time.deltaTime;

    }

}