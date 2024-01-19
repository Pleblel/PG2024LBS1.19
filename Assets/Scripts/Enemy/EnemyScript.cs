using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    public Vector2 dir;
    public float mvmSpeedEnemy;

    Rigidbody2D EnemyRigidBody;
    void Start()
    {
        // Gets Rigidbody2D component of gameObject. - Elm
        EnemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //This If statement is intended to stop the enemy if it is past a certain point. Used to render cloned enemy bases useless by crippling their movement. - Elm
        if (gameObject.transform.position.x > 500)
        {
            return;
        }

        // Creates a vector of a desired magnitude that points towards the player. The vector is applied to the velocity. - Elm
        dir = Player.transform.position - transform.position;
        Vector2 dirForce = dir.normalized * mvmSpeedEnemy;
        EnemyRigidBody.velocity = dirForce;
    }
}
