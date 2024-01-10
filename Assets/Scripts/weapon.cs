using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class weapon : MonoBehaviour
{
    public GameObject spell1;
    public GameObject weapHand;
    float cooldown = 0;
    public float cooldownLim1;
    public float cooldownLim2;
    public float cooldownLim3;
    public float cooldownLim4;
    public int spell;
    void Update()
    {
        cooldown += 1 * Time.deltaTime;
        spell1Func();
        spell2Func();
        spell3Func();
        spell4Func();
        spellSwap();
    }
    public void spell1Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim1 && spell == 0)
        {
            Quaternion rotation = weapHand.transform.rotation;
            Instantiate(spell1, transform.position, rotation);
            cooldown = 0;
        }
    }
    public void spell2Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim2 && spell == 1)
        {
            Quaternion rotation = weapHand.transform.rotation;
            Instantiate(spell1, transform.position, rotation);
            cooldown = 0;
        }
    }
    public void spell3Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim3 && spell == 2)
        {
            Quaternion rotation = weapHand.transform.rotation;
            Instantiate(spell1, transform.position, rotation);
            cooldown = 0;
        }
    }
    public void spell4Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim2 && spell == 3)
        {
            Quaternion rotation = weapHand.transform.rotation;
            Instantiate(spell1, transform.position, rotation);
            cooldown = 0;
        }
    }
    public void spellSwap()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spell += 1;
        }
        if (Input.GetKey(KeyCode.F) && spell == 4)
        {
            spell = 0;
        }
    }
}
