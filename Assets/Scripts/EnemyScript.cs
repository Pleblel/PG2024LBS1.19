using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    private Vector2 vMove;
    public float mvmSpeedEnemy;

    Rigidbody2D EnemyRigidBody;
    void Start()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dir = Player.transform.position - transform.position;
        Vector2 dirForce = dir.normalized * mvmSpeedEnemy;
        EnemyRigidBody.velocity = dirForce;

    }
}
