using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    public Vector2 dir;
    public float mvmSpeedEnemy;

    Rigidbody2D EnemyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Player.transform.position - transform.position;
        Vector2 dirForce = dir.normalized * mvmSpeedEnemy;
        EnemyRigidBody.velocity = dirForce;
    }
}
