using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100;
    public int currenthealth;


    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }



    }
    void TakeDamage(int damage)
    {
        currenthealth -= damage;

        healthbar.SetHealth(currenthealth);
    }
}


