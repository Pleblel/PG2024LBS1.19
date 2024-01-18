using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MooseAttack : MonoBehaviour
{
    public float mSpeed2;
    public GameObject player;
    public quaternion rot;
    public GameObject Proj1;
    public bool mooseClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets "MooseTooClose" bool value
        mooseClose = GetComponent<Moose>().MooseTooClose;

        Vector2 dir = transform.position - player.transform.position;

        //sätter vinkel
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //rotar boken runt en position
        rot = Quaternion.AngleAxis(angle, Vector3.forward);


        if (mooseClose == false)
        {
            var spellInstance = Instantiate(Proj1, gameObject.transform.position, rot);
            spellInstance.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0.01f * mSpeed2, 0));

        }
        
        
    }

    
}
