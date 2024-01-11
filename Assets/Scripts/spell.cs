using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class spell : MonoBehaviour
{
    public Rigidbody2D rb;
    public float mSpeed1;
    public float mSpeed2;
    public float mSpeed3;
    public GameObject weap;
    public GameObject rotation;
    public int spells;
    public void spellCast()
    {
        transform.rotation = rotation.transform.rotation;
        Vector3 mousePos = Input.mousePosition;
        weapon multSpl = weap.GetComponent<weapon>();,
        if (multSpl.spells == 0)
        {
            Quaternion rotation = transform.rotation;
            var spellInstance = Instantiate(gameObject, weap.transform.position, rotation);
            spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed1, 0));

        }
        if (multSpl.spells == 1)
        {
            Quaternion rotation = transform.rotation;
            var spellInstance = Instantiate(gameObject, weap.transform.position, rotation);
            spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed2, 0));
            spellInstance.transform.localScale = new Vector3(2, 2, 0);
        }
        if (multSpl.spells == 2)
        {
            Quaternion rotation = transform.rotation;
            var spellInstance = Instantiate(gameObject, weap.transform.position, rotation);
            spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed3, 0));
         }
        if (multSpl.spells == 3)
        {
            var spellInstance = Instantiate(gameObject, mousePos, Quaternion.identity);
        }
    }
}

