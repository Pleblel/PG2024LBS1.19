using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Moose : MonoBehaviour
{
    //Movement script
    public GameObject Player;
    public Vector2 dir;
    public float mvmSpeedMoose;
    Rigidbody2D MooseRigidBody;
    public float distanceMoose;
    public bool MooseTooClose;
    public float MARS;
    public float distanceMoose2;
    float timer;
    public float countingCooldown;
    private void Start()
    {
        //body is rigid
        MooseRigidBody = GetComponent<Rigidbody2D>();
        MooseTooClose = false;
    }


    private void Update()
    {
        Vector2 newPlayerPos = Player.transform.position - gameObject.transform.position;
        timer += Time.deltaTime;
        if (MooseTooClose == false && countingCooldown >= 150f)
        {
            StartCoroutine(CloseAttackMethod());
        }
        
        //moose close charge attack
        if (MooseTooClose == true && timer > 5)
        {
            // Creates a vector of a desired magnitude that points towards the player. The vector is applied to the velocity. 
            dir = Player.transform.position - transform.position;
            Vector2 dirForce3 = dir.normalized * MARS;
            MooseRigidBody.velocity = dirForce3;
            //resets cooldown
            countingCooldown = 0f;
            return;
        }
        if (Mathf.Abs(newPlayerPos.x) < distanceMoose2 && Mathf.Abs(newPlayerPos.y) < distanceMoose2)
        {
          //keeps a set distance between player and boss
          Vector2 Mooserandom = new Vector2(newPlayerPos.x * -1, newPlayerPos.y * -1);
          Vector2 dirForce2 = Mooserandom.normalized * mvmSpeedMoose;
          MooseRigidBody.velocity = dirForce2;
            countingCooldown += Time.deltaTime;
            
           return;
        }
        // Creates a vector of a desired magnitude that points towards the player. The vector is applied to the velocity. 
        dir = Player.transform.position - transform.position;
        Vector2 dirForce = dir.normalized * mvmSpeedMoose;
        MooseRigidBody.velocity = dirForce;
        countingCooldown++;
    }

    //Moose attack if player = too close
    public IEnumerator CloseAttackMethod()
    {
        //Checks for Player Position and sets bool to TRUE
        Vector2 newPlayerPos2 = Player.transform.position - gameObject.transform.position;
        if (Mathf.Abs(newPlayerPos2.x) < distanceMoose && Mathf.Abs(newPlayerPos2.y) < distanceMoose)
        {
            Debug.Log("RUN IT DOWN");
            MooseTooClose = true;
            yield return new WaitForSeconds(7);
        }
    }

    //checks for collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("moose is not close enough");
            MooseTooClose = false;
            timer = 0f;
            
        }
    }
}
