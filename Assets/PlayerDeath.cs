using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    public void PlayerDeathAnimation()
    {
        transform.position = player.transform.position;
        GetComponent<Animator>().Play("");
    }
}
