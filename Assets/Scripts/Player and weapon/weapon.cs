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
    float counting;
    [SerializeField] private AudioClip fireSpellSFX;
    void Update()
    {
        //cooldown f�r spell
        cooldown += 1 * Time.deltaTime;
        
        //aktiverar spellkoderna
        if (Input.GetKey(KeyCode.Mouse0))
        {
            spell1Func();
            spell2Func();
            spell3Func();
            spell4Func();
        }

        //aktiverar funktinen som kollar om man byter spell
        spellSwap();
    }

    //vatten
    public void spell1Func()
    {
        //kollar om man klickar, inte �r p� cooldown och om det �r den man vill anv�nda
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim1 && spells == 0)
        {
            //s�tter cooldwon till 0 och s�ger till att vatten ska sjutas
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }

    //�ld
    public void spell2Func()
    {
        //kollar om man klickar, inte �r p� cooldown och om det �r den man vill anv�nda
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim2 && spells == 1)
        {
            //kod f�r att spela �ld fx
            counting++;
            if (counting == 50)
            {
                SoundFXManager.instance.PlaySoundFXclip(fireSpellSFX, transform, 1f);
                counting = 0;
            }
            
            //s�tter cooldwon till 0 och s�ger till att �ld ska sjutas
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }

    //sten
    public void spell3Func()
    {
        //kollar om man klickar, inte �r p� cooldown och om det �r den man vill anv�nda
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim3 && spells == 2)
        {
            //s�tter cooldwon till 0 och s�ger till att sten ska sjutas
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }

    //blixt
    public void spell4Func()
    {
        //kollar om man klickar, inte �r p� cooldown och om det �r den man vill anv�nda
        if (Input.GetKey(KeyCode.Mouse0) && cooldown >= cooldownLim4 && spells == 3)
        {
            //s�tter cooldwon till 0 och s�ger till att blixt ska sjutas
            spell multSpl = spell1.GetComponent<spell>();
            multSpl.spellCast();
            cooldown = 0;
        }
    }

    //byta spell
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
