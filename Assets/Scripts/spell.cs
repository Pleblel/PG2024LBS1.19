using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class spell : MonoBehaviour
{
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
    public void spellCast()
    {
        transform.rotation = rotation.transform.rotation;

        weapon multSpl = weap.GetComponent<weapon>();
        spells = multSpl.spells;
        if (spells == 0 && mana.GetComponent<manaScript>().currentMana >= manaUse1)
        {
            mana.GetComponent<manaScript>().UseMana(manaUse1);
            StartCoroutine(spell0());
        }
        if (spells == 1 && mana.GetComponent<manaScript>().currentMana >= manaUse2)
        {
            mana.GetComponent<manaScript>().UseMana(manaUse2);
            StartCoroutine(spell1());
        }
        if (spells == 2 && mana.GetComponent<manaScript>().currentMana >= manaUse3)
        {
            mana.GetComponent<manaScript>().UseMana(manaUse3);
            StartCoroutine(spell2());
        }
        if (spells == 3 && mana.GetComponent<manaScript>().currentMana >= manaUse4)
        {
            mana.GetComponent<manaScript>().UseMana(manaUse4);
            StartCoroutine(spell3());
        }
    }
    private void Update()
    {
        ar.SetFloat("Horizontal", Camera.main.ScreenToWorldPoint(Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)).x);
        ar.SetFloat("Vertical", Camera.main.ScreenToWorldPoint(Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)).y);
    }
    IEnumerator spell0()
    {
        Quaternion rotation = transform.rotation;
        var spellInstance = Instantiate(main, weap.transform.position, rotation);
        var spellHitbox = Instantiate(hitbox1, weap.transform.position, rotation);
        spellInstance.GetComponent<Animator>().Play("Water_anim");
        spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed1, 0));
        spellHitbox.transform.parent = spellInstance.transform;
        yield return new WaitForSecondsRealtime(5);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }
    IEnumerator spell1()
    {
        Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-30, 30));
        var spellInstance = Instantiate(main, weap.transform.position, rotation);
        var spellHitbox = Instantiate(hitbox2, weap.transform.position, rotation);
        spellInstance.GetComponent<Animator>().Play("Fire_anim");
        spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed2, 0));
        spellHitbox.transform.parent = spellInstance.transform;
        yield return new WaitForSecondsRealtime(1);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }
    IEnumerator spell2()
    {
        Quaternion rotation = transform.rotation;
        var spellInstance = Instantiate(main, weap.transform.position, rotation);
        var spellHitbox = Instantiate(hitbox3, weap.transform.position, rotation);
        spellInstance.GetComponent<Animator>().Play("Stone_anim");
        spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed3, 0));
        spellHitbox.transform.parent = spellInstance.transform;
        yield return new WaitForSecondsRealtime(10);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }
    IEnumerator spell3()
    {
        Quaternion rotation = transform.rotation;
        var spellInstance = Instantiate(main, weap.transform.position, Quaternion.identity);
        var spellHitbox = Instantiate(hitbox4, weap.transform.position, Quaternion.identity);
        spellInstance.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 5, 0);
        spellHitbox.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        spellInstance.GetComponent<Animator>().Play("Lightning_anim");
        yield return new WaitForSecondsRealtime(1);
        Destroy(spellInstance);
        Destroy(spellHitbox);
    }
}

