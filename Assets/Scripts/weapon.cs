using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
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
    public int spells;
    void Update()
    {
        cooldown += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            spell1Func();
            spell2Func();
            spell3Func();
            spell4Func();
        }
        spellSwap();
    }
    public void spell1Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim1 && spells == 0)
        {
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }
    public void spell2Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim2 && spells == 1)
        {
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }
    public void spell3Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim3 && spells == 2)
        {
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }
    public void spell4Func()
    {
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim4 && spells == 3)
        {
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }
    public void spellSwap()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spells += 1;
        }
        if (Input.GetKey(KeyCode.F) && spells == 4)
        {
            spells = 0;
        }
    }
}
