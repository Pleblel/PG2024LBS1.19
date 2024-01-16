using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class spell : MonoBehaviour
{
    //Pelle
    public Rigidbody2D rb;
    public float mSpeed1;
    public float mSpeed2;
    public float mSpeed3;
    public GameObject weap;
    public GameObject rotation;
    public GameObject main;
    public GameObject hitbox4;
    public GameObject hitbox3;
    public GameObject hitbox2;
    public GameObject hitbox1;
    public int spells;
    public SpriteRenderer sr;
    public GameObject mana;
    public float manaUse1;
    public float manaUse2;
    public float manaUse3;
    public float manaUse4;
    public Animator ar;
    [SerializeField] private AudioClip waterSpellSFX;
    [SerializeField] private AudioClip boulderSFX;
    [SerializeField] private AudioClip lightningSFX;

    //kallas när man klickar högerklick
    public void spellCast()
    {
        transform.rotation = rotation.transform.rotation;
        //tar vapen skripten
        weapon multSpl = weap.GetComponent<weapon>();
        spells = multSpl.spells;

        //kollar vilken det är och om man har mana nog
        if (spells == 0 && mana.GetComponent<manaScript>().currentMana >= manaUse1)
        {
            //tar mana och startar spell koden
            mana.GetComponent<manaScript>().UseMana(manaUse1);
            StartCoroutine(spell0());
        }

        //kollar vilken det är och om man har mana nog
        if (spells == 1 && mana.GetComponent<manaScript>().currentMana >= manaUse2)
        {
            //tar mana och startar spell koden
            mana.GetComponent<manaScript>().UseMana(manaUse2);
            StartCoroutine(spell1());
        }

        //kollar vilken det är och om man har mana nog
        if (spells == 2 && mana.GetComponent<manaScript>().currentMana >= manaUse3)
        {
            //tar mana och startar spell koden
            mana.GetComponent<manaScript>().UseMana(manaUse3);
            StartCoroutine(spell2());
        }

        //kollar vilken det är och om man har mana nog
        if (spells == 3 && mana.GetComponent<manaScript>().currentMana >= manaUse4)
        {
            //tar mana och startar spell koden
            mana.GetComponent<manaScript>().UseMana(manaUse4);
            StartCoroutine(spell3());
        }
    }
    
    //vatten
    IEnumerator spell0()
    {
        //sätter rikting, spawnar hitbox och visuals 
        Quaternion rotation = transform.rotation;
        var spellInstance = Instantiate(main, weap.transform.position, rotation);
        var spellHitbox = Instantiate(hitbox1, weap.transform.position, rotation);
        spellInstance.GetComponent<Animator>().Play("Water_anim");

        //plays Water Audio
        SoundFXManager.instance.PlaySoundFXclip(waterSpellSFX, transform, 1f);

        //sätter rörelsen 
        spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed1, 0));
        spellHitbox.transform.parent = spellInstance.transform;

        //väntar och förstör
        yield return new WaitForSecondsRealtime(5);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }

    //äld
    IEnumerator spell1()
    {
        //sätter rikting, spawnar hitbox och visuals 
        Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-30, 30));
        var spellInstance = Instantiate(main, weap.transform.position, rotation);
        var spellHitbox = Instantiate(hitbox2, weap.transform.position, rotation);
        spellInstance.GetComponent<Animator>().Play("Fire_anim");

        //sätter rörelsen 
        spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed2, 0));
        spellHitbox.transform.parent = spellInstance.transform;

        //väntar och förstör
        yield return new WaitForSecondsRealtime(1);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }

    //sten
    IEnumerator spell2()
    {
        //sätter rikting, spawnar hitbox och visuals 
        Quaternion rotation = transform.rotation;
        var spellInstance = Instantiate(main, weap.transform.position, rotation);
        var spellHitbox = Instantiate(hitbox3, weap.transform.position, rotation);
        spellInstance.GetComponent<Animator>().Play("Stone_anim");

        //play sound FX for boulder
        SoundFXManager.instance.PlaySoundFXclip(boulderSFX, transform, 1f);

        //sätter rörelsen 
        spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed3, 0));
        spellHitbox.transform.parent = spellInstance.transform;

        //väntar och förstör
        yield return new WaitForSecondsRealtime(10);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }

    //blixt
    IEnumerator spell3()
    {
        //spawnar blixt och hitbox
        var spellInstance = Instantiate(main, weap.transform.position, Quaternion.identity);
        var spellHitbox = Instantiate(hitbox4, weap.transform.position, Quaternion.identity);
        //sätter plats för blixt 

        spellInstance.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 5, 0);
        spellHitbox.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        spellInstance.GetComponent<Animator>().Play("Lightning_anim");

        //play sound FX for Lightning
        SoundFXManager.instance.PlaySoundFXclip(lightningSFX, transform, 1f);

        //väntar och förstör
        yield return new WaitForSecondsRealtime(1);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }
}

