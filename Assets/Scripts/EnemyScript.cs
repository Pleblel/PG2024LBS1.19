using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    GameObject gameObject;

    private Vector2 vMove;
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
        Vector2 dir = Player.transform.position - transform.position;
        Vector2 dirForce = dir.normalized * mvmSpeedEnemy;
        EnemyRigidBody.velocity = dirForce;
        if (Mathf.Abs(dir.x) <= 0.7f || Mathf.Abs(dir.y) <= 0.7f)
        {
            EnemyAttack();
        }
    }

    public void EnemyAttack()
    {





    }
}
